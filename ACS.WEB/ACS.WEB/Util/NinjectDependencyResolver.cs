using ACS.BLL.Interfaces;
using ACS.BLL.Services;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ACS.WEB.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IAccountAppUserService>().To<AccountAppUserService>();
            kernel.Bind<IEmployeeService>().To<IEmployeeService>();
            kernel.Bind<IApplicationUserService>().To<ApplicationUserService>();
            kernel.Bind<IApplicationRoleService>().To<ApplicationRoleService>();
            kernel.Bind<IChancelleryService>().To<ChancelleryService>();
            kernel.Bind<IFolderChancelleryService>().To<FolderChancelleryService>();
            kernel.Bind<IJournalRegistrationsChancelleryService>().To<JournalRegistrationsChancelleryService>();
            kernel.Bind<ITypeRecordChancelleryService>().To<TypeRecordChancelleryService>();
            kernel.Bind<IExternalOrganizationService>().To<ExternalOrganizationService>();
            kernel.Bind<IFilesSevice>().To<FilesService>();
        }
    }
}