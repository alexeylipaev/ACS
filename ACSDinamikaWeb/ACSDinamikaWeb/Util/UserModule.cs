using ACS.BLL.Interfaces;
using ACS.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACSWeb.Util
{
    public class UserModule : NinjectModule
    {
        public override void Load() 
        {
            Bind<IUserService>().To<UserService>();
        }
    }

    public class AccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccessService>().To<AccessService>();
        }
    }
}