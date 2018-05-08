using System;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Interfaces
{
    /// <summary>
    /// Интерфейс единицы работы для асинхронного выполнения
    /// </summary>
    public interface IUnitOfWorkAsync : IDisposable
    {
        /// <summary>
        /// Сохранить ВСЕ изменения в базу
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Создать репозиторий, привязанный к UnitOfWorkAsync
        /// </summary>
        IRepositoryAsync<TEntity> CreateRepository<TEntity>() where TEntity : class, IEntity;
    }
}
