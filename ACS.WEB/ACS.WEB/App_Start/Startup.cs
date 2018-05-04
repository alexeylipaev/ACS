
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ACS.BLL.Services;
using Microsoft.AspNet.Identity;
using ACS.BLL.Interfaces;
using ACS.BLL;
/*
Startup.cs: поскольку в приложении MVC 5 используются библиотеки, применяющие спецификацию OWIN, 
то данный файл организует связь между OWIN и приложением. 
(OWIN представляет спецификацию, описывающую взаимодействие между компонентами приложения)
*/
[assembly: OwinStartupAttribute(typeof(ACS.WEB.App_Start.Startup))]

namespace ACS.WEB.App_Start
{
    public partial class Startup
    {
        /// <summary>
        /// С помощью фабрики сервисов здесь создается сервис для работы с сервисами
        /// </summary>
        /// 
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
      
            //Потом сервис региструется контекстом OWIN:
            app.CreatePerOwinContext(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IApplicationUserService CreateUserService()
        {
            //здесь предполагается, что в файле web.config имеется строка подключения DefaultConnection, которая передается в метод 
            return serviceCreator.CreateUserService(Сonnection.@string);
        }
    }

    //public partial class Startup
    //{
    //    // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
    //    public void ConfigureAuth(IAppBuilder app)
    //    {
    //        return;
    //        FormsAuthentication fa = new FormsAuthentication();

    //        // Configure the db context, user manager and signin manager to use a single instance per request
    //        app.CreatePerOwinContext(ACSContext.Create);
    //        app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
    //        app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

    //        // Enable the application to use a cookie to store information for the signed in user
    //        // and to use a cookie to temporarily store information about a user logging in with a third party login provider
    //        // Configure the sign in cookie
    //          app.UseCookieAuthentication(new CookieAuthenticationOptions 
    //          { 
    //              AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, 
    //              LoginPath = new PathString("/Account/Login"), 
    //              Provider = new CookieAuthenticationProvider 
    //              { 
    //                  OnValidateIdentity = SecurityStampValidator
    //                      .OnValidateIdentity<ApplicationUserManager, ApplicationUser, int>(
    //                          validateInterval: TimeSpan.FromMinutes(30), 
    //                          regenerateIdentityCallback: (manager, user) => 
    //                              user.GenerateUserIdentityAsync(manager), 
    //                          getUserIdCallback:(id)=>(id.GetUserId<int>()))
    //              } 
    //          });         
    //        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

    //        // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
    //        app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

    //        // Enables the application to remember the second login verification factor such as phone or Email.
    //        // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
    //        // This is similar to the RememberMe option when you log in.
    //        app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

    //        // Uncomment the following lines to enable logging in with third party login providers
    //        //app.UseMicrosoftAccountAuthentication(
    //        //    clientId: "",
    //        //    clientSecret: "");

    //        //app.UseTwitterAuthentication(
    //        //   consumerKey: "",
    //        //   consumerSecret: "");

    //        //app.UseFacebookAuthentication(
    //        //   appId: "",
    //        //   appSecret: "");

    //        //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
    //        //{
    //        //    ClientId = "",
    //        //    ClientSecret = ""
    //        //});
    //    }
    //}
}