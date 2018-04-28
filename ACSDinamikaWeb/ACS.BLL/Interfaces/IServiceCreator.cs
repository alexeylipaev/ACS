using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    /// <summary>
    /// абстрактная фабрика. 
    /// Хотя естественнно можно также использовать для внедрения зависимостей DI-контейнеры типа Ninject.
    /// </summary>
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
}
