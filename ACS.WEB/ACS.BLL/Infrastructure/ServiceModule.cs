using ACS.BLL.Interfaces;
using ACS.BLL.Services;
using ACS.DAL.Interfaces;
using ACS.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Infrastructure
{
    /// <summary>
    /// ServiceModule представляет специальный модуль Ninject, который служит для организации сопоставления зависимостей. В частности, он устанавливает использование EFUnitOfWork в качестве объекта IUnitOfWork.
    /// Кроме того, здесь через конструктор передается название подключения, которое в итоге будет определяться в файле web.config проекта, представляющего уровень представления.
    /// </summary>
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);

        }
    }
}
