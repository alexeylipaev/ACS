using ACS.DAL.Entities;

//using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ACS.DAL.Interfaces
{
    /// <summary>
    /// Интерфейс асинхронного репозитория для сущности типа {T}
    /// </summary>
    /// <typeparam name="T">Cущность доменной модели</typeparam>
    public interface IRepositoryAsync<T> : IRepository<T>
        where T : class
    {

        Task<List<T>> ToListAsync(bool noTracking = false);

        /// <summary>
        /// Асинхронно получить все сущности
        /// </summary>
        /// <param name="noTracking">Возвращаемые сущности не привязаны к сессии</param>
        /// <returns>Задача, возвращающая все сущности</returns>

        Task<List<T>> GetAllAsync(bool noTracking = false);

        /// <summary>
        /// Асинхронно найти сущность по ключу (или составному ключу).
        /// </summary>
        /// <param name="id">Ключ (или составной ключ)</param>
        /// <returns>Задача, возвращающая найденную сущность или null если сущность не найдена</returns>
       
        Task<T> FindAsync(params object[] id);

   
        Task<int> AddAsync(T entity/*, int EditorId*/);

        /// <summary>
        /// Асинхронно добавить заданную коллекцию сущностей к контексту
        /// </summary>
        /// <param name="entities">Коллекция сущностей для добавления</param>
        /// <returns>Задача, возвращающая количество измененных/сохраненных объектов</returns>
        Task<int> AddRangeAsync( IEnumerable<T> entities/*, int EditorId*/);

        Task<int> AddOrUpdateAsync(T entity/*, int EditorId*/);

        /// <summary>
        /// Асинхронно добавить заданную коллекцию сущностей к контексту. 
        /// Если сущность существует, то обновить сущность в контексте
        /// </summary>
        /// <param name="entities">Коллекция сущностей для добавления/обновления</param>
        /// <returns>Задача, возвращающая количество добавленных/измененных объектов</returns>

        Task<int> AddOrUpdateAsync( T[] entities/*, int EditorId*/);

        /// <summary>
        /// Добавить заданную коллекцию сущностей к контексту. 
        /// Если сущность существует, то обновить сущность в контексте
        /// </summary>
        /// <param name="entities">Коллекция сущностей для добавления/обновления</param>
        /// <param name="identifier">Выражение, определяющее свойства, которые должны быть использованы при определении 
        /// надо ли провести операцию добавления или обновления.</param>
        /// <returns>Задача, возвращающая количество добавленных/измененных объектов</returns>

        Task<int> AddOrUpdateAsync( T[] entities, Expression<Func<T, object>> identifier/*, int EditorId*/);

        Task<int> UpdateAsync(T entity/*, int EditorId*/);

        Task<int> DeleteAsync(T entity);
        Task<int> DeleteAsync(int id);
        /// <summary>
        /// Асинхронно удалить сущности по условию в контексте
        /// </summary>
        /// <param name="filter">Условие отбора сущностей для удаления</param>
        /// <returns>Задача, удаляющая сущности по условию, возвращающая количество удаленных объектов</returns>

        Task<int> DeleteAllAsync( Expression<Func<T, bool>> filter);

        /// <summary>
        /// Асинхронно получить количество всех (или по условию) элементов в коллекции
        /// </summary>
        /// <param name="filter">Условие отбора сущностей</param>
        /// <returns>Задача, возвращающая количество элементов в коллекции</returns>
       
        Task<long> CountAsync( Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Асинхронный запрос на получение сущностей из контекста
        /// </summary>
        /// <param name="filter">Условие отбора сущностей</param>
        /// <param name="noTracking">Возвращаемые сущности не привязаны к сессии</param>
        /// <param name="orderBy">Условие сортировки</param>
        /// <param name="include">Сущности включаемые в результат запроса</param>
        /// <returns>Задача, возвращающая найденные сущности</returns>
       
        Task<IList<T>> QueryAsync(
             Expression<Func<T, bool>> filter,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool noTracking = false,
            params Expression<Func<T, object>>[] include);

        /// <summary>
        /// Асинхронный запрос на получение сущностей из контекста
        /// </summary>
        /// <param name="filter">Условие отбора сущностей</param>
        /// <param name="orderBy">Условие сортировки</param>
        /// <param name="include">Сущности включаемые в результат запроса</param>
        /// <returns>Задача, возвращающая найденные сущности</returns>
       
        Task<IList<T>> QueryAsync(
             Expression<Func<T, bool>> filter,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] include);

        /// <summary>
        /// Асинхронный запрос на получение сущностей из контекста
        /// </summary>
        /// <param name="filter">Условие отбора сущностей</param>
        /// <param name="noTracking">Возвращаемые сущности не привязаны к сессии</param>
        /// <param name="include">Сущности включаемые в результат запроса</param>
        /// <returns>Задача, возвращающая найденные сущности</returns>
       
        Task<IList<T>> QueryAsync(
             Expression<Func<T, bool>> filter,
            bool noTracking = false,
            params Expression<Func<T, object>>[] include);

        /// <summary>
        /// Асинхронный запрос на получение сущностей из контекста
        /// </summary>
        /// <param name="filter">Условие отбора сущностей</param>
        /// <param name="include">Сущности включаемые в результат запроса</param>
        /// <returns>Задача, возвращающая найденные сущности</returns>
       
        Task<IList<T>> QueryAsync(
             Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] include);

        /// <summary>
        /// Асинхронный запрос на получение сущности из контекста
        /// </summary>
        /// <param name="callback">Условие отбора сущности</param>
        /// <param name="noTracking">Возвращаемая сущность не привязаны к сессии</param>
        /// <returns>Задача, возвращающая найденную сущность</returns>
       
        Task<T> QueryAsync( Func<IQueryable<T>, Task<T>> callback, bool noTracking = false);

        /// <summary>
        /// Асинхронный запрос на получение проекции сущности из контекста
        /// </summary>
        /// <param name="callback">Условие отбора проекции</param>
        /// <param name="noTracking">Возвращаемая сущность не привязаны к сессии</param>
        /// <returns>Задача, возвращающая найденную проекцию</returns>
       
        Task<TResult> QueryAsync<TResult>( Func<IQueryable<T>, Task<TResult>> callback, bool noTracking = false);

        ///// <summary>
        ///// Асинхронный запрос на получение постраничного вывода сущностей из контекста.
        ///// Работает только с заданным условием сортировки
        ///// </summary>
        ///// <param name="pageNumber">Номер страницы (начинается с 1)</param>
        ///// <param name="pageSize">Количество записей на странице (минимальное 1)</param>
        ///// <param name="filter">Условие отбора сущностей</param>
        ///// <param name="orderBy">Условие сортировки</param>
        ///// <param name="include">Сущности включаемые в результат запроса</param>
        ///// <returns>Найденные сущности</returns>
       
        //Task<IPagedList<T>> PagedAsync(int pageNumber, int pageSize,
        //     Expression<Func<T, bool>> filter,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        //    params Expression<Func<T, object>>[] include);

        //#region Methods immediately executed, pass by tracking system

        ///// <summary>
        ///// Асинхронно удалить сущности по условию в контексте.
        ///// Метод выполняется немедленно, минуя систему трекинга.
        ///// Изменения не будут отражаться на сущностях в текущем контексте.
        ///// </summary>
        ///// <param name="filter">Условие отбора сущностей для удаления</param>
        ///// <returns>Задача, возвращающая количество удаленных объектов</returns>
        //Task<int> DeleteImmediatelyAsync( Expression<Func<T, bool>> filter);

        ///// <summary>
        ///// Асинхронно обновить сущности по условию в контексте.
        ///// Метод выполняется немедленно, минуя систему трекинга.
        ///// Изменения не будут отражаться на сущностях в текущем контексте.
        ///// </summary>
        ///// <param name="filter">Условие отбора сущностей для обновления</param>
        ///// <param name="updater">Выражение указывает, какие поля необходимо обновить</param>
        ///// <returns>Задача, возвращающая количество обновленных объектов</returns>
        //Task<int> UpdateImmediatelyAsync( Expression<Func<T, bool>> filter, Expression<Func<T, T>> updater);

        //#endregion
    }
}