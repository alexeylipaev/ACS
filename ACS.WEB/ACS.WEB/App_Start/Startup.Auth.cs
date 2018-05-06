using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.App_Start
{
    public static class MyAuthentication
    {
        public const String ApplicationCookie = "MyProjectAuthenticationType";
    }

    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);
            // need to add UserManager into owin, because this is used in cookie invalidation
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //AuthenticationType = MyAuthentication.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider(),
                CookieName = "MyCookieName",
                CookieHttpOnly = true,
                ExpireTimeSpan = TimeSpan.FromHours(12), // adjust to your needs
            });
        }
    }
}