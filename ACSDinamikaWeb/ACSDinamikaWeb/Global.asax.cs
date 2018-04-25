using ACS.BLL.Infrastructure;
using ACSWeb.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

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
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            NinjectModule accessModule = new AccessModule();
            var kernel2 = new StandardKernel(accessModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel2));
        }
    }
}
