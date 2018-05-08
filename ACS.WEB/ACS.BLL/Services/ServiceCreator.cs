using ACS.BLL.Interfaces;
using ACS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IAccountAppUserService CreateAccountUserService(string connection)
        {
            return new AccountAppUserService(new UnitOfWork(connection));
        }
    }
}
