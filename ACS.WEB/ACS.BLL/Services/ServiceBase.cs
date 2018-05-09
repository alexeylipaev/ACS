using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Services
{
     
   /// <summary>
   /// Абстрактный базовый класс сервиса
   /// </summary>
    public abstract class ServiceBase
    {
        private IUnitOfWork db;

        public ServiceBase(IUnitOfWork uow)
        {
            this.db = uow;
        }

        protected virtual IUnitOfWork Database
        {
            get { return db; }
        }
    }
}