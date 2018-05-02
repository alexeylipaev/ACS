using ACS.BLL.Interfaces;
using ACS.BLL.Services;
using ACS.WEB.Providers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load() 
        {
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IAccessService>().To<AccessService>();
            Bind<IApplicationUserService>().To<ApplicationUserService>()/*.WithConstructorArgument(connectionString)*/;
        }
    }

}