using ACS.BLL.Infrastructure;
using ACSWeb.Util;
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
namespace ACSWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule serviceModule = new ServiceModule("ACSContextConnection");

            NinjectModule userModule = new UserModule();
            var kernel = new StandardKernel(userModule, serviceModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            //NinjectModule accessModule = new AccessModule();
            //var kernel2 = new StandardKernel(accessModule, serviceModule);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel2));
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
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
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated && HttpContext.Current.User.Identity is WindowsIdentity)
            {
                // note that we will be stripping the domain from the username as forms authentication doesn't capture this anyway

                // create a temp cookie for this request only (not set in response)
                var tempCookie = FormsAuthentication.GetAuthCookie(Regex.Replace(HttpContext.Current.User.Identity.Name, ".*\\\\(.*)", "$1", RegexOptions.None), false);

                // set the user based on this temporary cookie - just for this request
                // we grab the roles from the identity we are replacing so that none are lost
                HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(FormsAuthentication.Decrypt(tempCookie.Value)), (HttpContext.Current.User.Identity as WindowsIdentity).Groups.Select(group => group.Value).ToArray());

                // now set the forms cookie
                FormsAuthentication.SetAuthCookie(HttpContext.Current.User.Identity.Name, false);
            }
        }

    }
}
