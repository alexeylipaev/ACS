using ACS.BLL;
using ACS.BLL.Infrastructure;
using ACS.WEB.Providers;
using ACS.WEB.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

/*
 Global.asax: файл, запускающийся при старте приложения и выполняющий начальную инициализацию. 
 Как правило, здесь срабатывают методы классов, определенных в папке App_Start
     */
namespace ACS.WEB
{
    /// <summary>
    /// Класс приложения поддерживает методы, которые позволяют 
    /// управлять жизненным циклом приложения
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Метод Application_Start вызывается при старте приложения
        /// </summary>
        protected void Application_Start()
        {
            //Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<ACSContext, ACS.DAL.Migrations.Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule serviceModule = new ServiceModule(Сonnection.@string);

            //NinjectModule userModule = new UserModule();
            //var kernel = new StandardKernel(userModule, serviceModule);
        
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            // внедрение зависимостей

            // внедрение зависимостей
            NinjectModule ninjectRegistrations = new NinjectRegistrations();
            var kernel = new StandardKernel(ninjectRegistrations, serviceModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            AddEvent("StartRequest");


        }

        /// <summary>
        /// Application_End - перед завершением его работы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if(this.Response.RedirectLocation != null)
            // we only want 302 redirects if they are for login purposes
            if (this.Response.StatusCode == 302 && this.Response.RedirectLocation.Contains("/login"))
            {
                // look for a setting on the QueryString to trigger a challenge
                if (!string.IsNullOrEmpty(Request.QueryString["internal"]))
                {
                    this.Response.StatusCode = 401;
                    // note that the following line is .NET 4.5 or later only
                    // otherwise you have to suppress the return URL etc manually!
                    this.Response.SuppressFormsAuthenticationRedirect = true;
                }
            }
            AddEvent("EndRequest");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (HttpContext.Current.User.Identity is WindowsIdentity)
            {
                    // note that we will be stripping the domain from the username as forms authentication doesn't capture this anyway
                    var wi = HttpContext.Current.User.Identity as WindowsIdentity;
                    string userLogin = ActiveDirectory.IdentityUserEmailFromActiveDirectory(wi.Name);
                    // create a temp cookie for this request only (not set in response)
                    string userName = Regex.Replace(HttpContext.Current.User.Identity.Name, ".*\\\\(.*)", "$1", RegexOptions.None);
                    //var tempCookie = FormsAuthentication.GetAuthCookie(Regex.Replace(HttpContext.Current.User.Identity.Name, ".*\\\\(.*)", "$1", RegexOptions.None), false);
                    var tempCookie = FormsAuthentication.GetAuthCookie(userLogin, false);

                    // set the user based on this temporary cookie - just for this request
                    // we grab the roles from the identity we are replacing so that none are lost
                    ACSRoleProvider acs = new Providers.ACSRoleProvider();
                    var roles = acs.GetRolesForUser(userLogin);

                    //HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(FormsAuthentication.Decrypt(tempCookie.Value)), (HttpContext.Current.User.Identity as WindowsIdentity).Groups.Select(group => group.Value).ToArray());
                    HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(FormsAuthentication.Decrypt(tempCookie.Value)), roles.ToArray());

                    // now set the forms cookie
                    FormsAuthentication.SetAuthCookie(HttpContext.Current.User.Identity.Name, false);
                }
            }
            AddEvent("AuthenticateRequest");
        }

        /// <summary>
        /// Для хранения информации о событиях 
        /// </summary>
        /// <param name="name"></param>
        private void AddEvent(string name)
        {
            List<string> eventList = Application["events"] as List<string>;
            if (eventList == null)
            {
                Application["events"] = eventList = new List<string>();
            }
            eventList.Add(name);
        }

    }
}
