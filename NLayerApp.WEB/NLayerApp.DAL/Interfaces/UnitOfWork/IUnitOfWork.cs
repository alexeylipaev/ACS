using NLayerApp.DAL.Entities;
using System;

namespace NLayerApp.DAL.Interfaces
{
    //public interface IUnitOfWork : IDisposable
    //{
    //    IRepository<Phone> Phones { get; }
    //    IRepository<Order> Orders { get; }
    //    void Save();
    //}
    /// <summary>
    /// Интерфейс единицы работы
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Phone> Phones { get; }
        IRepository<Order> Orders { get; }

        /// <summary>
        /// Сохранить ВСЕ изменения в базу
        /// </summary>
        void Commit();
    }
}

