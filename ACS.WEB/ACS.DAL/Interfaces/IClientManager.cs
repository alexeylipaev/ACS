using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Interfaces
{
    /// <summary>
    /// Данный интерфейс содержит один метод для создания нового профиля пользователя.
    /// </summary>
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
