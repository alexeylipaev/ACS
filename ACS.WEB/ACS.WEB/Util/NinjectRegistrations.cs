﻿using ACS.BLL.Interfaces;
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
            //Bind<IAccountAppUserService>().To<AccountAppUserService>()/*.WithConstructorArgument(connectionString)*/;
            Bind<IApplicationUserService>().To<ApplicationUserService>();
            Bind<IApplicationRoleService>().To<ApplicationRoleService>();
            Bind<IChancelleryService>().To<ChancelleryService>();
            Bind<IFolderChancelleryService>().To<FolderChancelleryService>();
            Bind<IJournalRegistrationsChancelleryService>().To<JournalRegistrationsChancelleryService>();
        }
    }

}