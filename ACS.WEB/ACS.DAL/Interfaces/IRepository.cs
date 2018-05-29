
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace ACS.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {

         List<T> ToList();

    
        /// <summary>
        /// Тип сущности, с которой работает данный репозиторий
        /// </summary>
        Type ObjectType { get; }
 

        /// <summary>
        /// Получить все сущности
        /// </summary>
        /// <param name="noTracking">Возвращаемые сущности не привязаны к сессии</param>
        /// <returns>Все сущности</returns>
        IList<T> GetAll(bool noTracking = false);

        /// <summary>
        /// Найти сущность по ключу (или составному ключу)
        /// </summary>
        /// <param name="id">Ключ (или составной ключ)</param>
        /// <returns>Найденная сущность или null если сущность не найдена</returns>
        T Find(params object[] id);

        IEnumerable<T> Find(Func<T, Boolean> predicate);

        bool Any(Func<T, Boolean> predicate);

        /// <summary>
        /// Добавить сущность к контексту
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        /// <returns>Количество добавленных объектов</returns>
        int Add(T entity, int EditorId);

        /// <summary>
        /// Добавить заданную коллекцию сущностей к контексту
        /// </summary>
        /// <param name="entities">Коллекция сущностей для добавления</param>
        /// <returns>Количество добавленных объектов</returns>
        int AddRange( IEnumerable<T> entities, int EditorId);

        /// <summary>
        /// Добавить сущность к контексту.
        /// Если сущность существует, то обновить сущность в контексте
        /// </summary>
        /// <param name="entity">Добавляемая/обновляемая сущность</param>
        /// <returns>Количество измененных/сохраненных объектов</returns>
        int AddOrUpdate( T entity, int EditorId);

        /// <summary>
        /// Добавить заданную коллекцию сущностей к контексту. 
        /// Если сущность существует, то обновить сущность в контексте
        /// </summary>
        /// <param name="entities">Коллекция сущностей для добавления/обновления</param>
        /// <returns>Количество измененных/сохраненных объектов</returns>
        int AddOrUpdate( T[] entities, int EditorId);

        /// <summary>
        /// Добавить сущность к контексту.
        /// Если сущность существует, то обновить сущность в контексте
        /// </summary>
        /// <param name="entity">Добавляемая/обновляемая сущность</param>
        /// <param name="identifier">Выражение, определяющее свойства, которые должны быть использованы при определении 
        /// надо ли провести операцию добавления или обновления.</param>
        /// <returns>Количество измененных/сохраненных объектов</returns>
        int AddOrUpdate( T entity, Expression<Func<T, object>> identifier, int EditorId);

        /// <summary>
        /// Добавить заданную коллекцию сущностей к контексту. 
        /// Если сущность существует, то обновить сущность в контексте
        /// </summary>
        /// <param name="entities">Коллекция сущностей для добавления/обновления</param>
        /// <param name="identifier">Выражение, определяющее свойства, которые должны быть использованы при определении 
        /// надо ли провести операцию добавления или обновления.</param>
        /// <returns>Количество измененных/сохраненных объектов</returns>
        int AddOrUpdate( T[] entities, Expression<Func<T, object>> identifier, int EditorId);

        /// <summary>
        /// Обновить сущность в контексте
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        /// <returns>Количество измененных/сохраненных объектов</returns>
        int Update( T entity, int EditorId);

        /// <summary>
        /// Удалить сущность в контексте
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        /// <returns>Количество удаленных объектов</returns>
        int Delete( T entity);
        int Delete(int id);
        /// <summary>
        /// Удалить сущность в контексте
        /// </summary>
        /// <param name="id">Идентификатор удаляемой сущности</param>
        /// <returns>Количество удаленных объектов</returns>
        int Delete(params object[] id);

        /// <summary>
        /// Удалить заданную коллекцию сущностей в контексте
        /// </summary>
        /// <param name="entities">Коллекция сущностей для удаления</param>
        /// <returns>Количество удаленных объектов</returns>
        int DeleteRange( IEnumerable<T> entities);

        /// <summary>
        /// Удалить сущности по условию в контексте
        /// </summary>
        /// <param name="filter">Условие отбора сущностей для удаления</param>
        /// <returns>Количество удаленных объектов</returns>
        int DeleteAll( Expression<Func<T, bool>> filter);

        /// <summary>
        /// Получить количество всех (или по условию) элементов в коллекции
        /// </summary>
        /// <param name="filter">Условие отбора сущностей</param>
        /// <returns>Количество элементов в коллекции</returns>
        long Count(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Запрос на получение сущностей из контекста
        /// </summary>
        /// <param name="filter">Условие отбора сущностей</param>
        /// <param name="noTracking">Возвращаемые сущности не привязаны к сессии</param>
        /// <param name="orderBy">Условие сортировки</param>
        /// <param name="include">Сущности включаемые в результат запроса</param>
        /// <returns>Найденные сущности</returns>
        
        IList<T> Query(
             Expression<Func<T, bool>> filter,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool noTracking = false,
            params Expression<Func<T, object>>[] include);

        /// <summary>
        /// Запрос на получение сущностей из контекста
        /// </summary>
        /// <param name="filter">Условие отбора сущностей</param>
        /// <param name="orderBy">Условие сортировки</param>
        /// <param name="include">Сущности включаемые в результат запроса</param>
        /// <returns>Найденные сущности</returns>
        
        IList<T> Query(
             Expression<Func<T, bool>> filter,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] include);

        /// <summary>
        /// Запрос на получение сущностей из контекста
        /// </summary>
        /// <param name="filter">Условие отбора сущностей</param>
        /// <param name="noTracking">Возвращаемые сущности не привязаны к сессии</param>
        /// <param name="include">Сущности включаемые в результат запроса</param>
        /// <returns>Найденные сущности</returns>
        
        IList<T> Query(
             Expression<Func<T, bool>> filter,
            bool noTracking = false,
            params Expression<Func<T, object>>[] include);

        /// <summary>
        /// Запрос на получение сущностей из контекста
        /// </summary>
        /// <param name="filter">Условие отбора сущностей</param>
        /// <param name="include">Сущности включаемые в результат запроса</param>
        /// <returns>Найденные сущности</returns>
        
        IList<T> Query(
             Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] include);

        /// <summary>
        /// Запрос на получение сущностей из контекста
        /// </summary>
        /// <param name="callback">Условие отбора сущности</param>
        /// <param name="noTracking">Возвращаемая сущность не привязаны к сессии</param>
        /// <returns>Найденная сущность</returns>
        
        T Query( Func<IQueryable<T>, T> callback, bool noTracking = false);


        /// <summary>
        /// Запрос на получение проекции сущности из контекста
        /// </summary>
        /// <param name="callback">Условие отбора проекции</param>
        /// <param name="noTracking">Возвращаемая сущность не привязаны к сессии</param>
        /// <returns>Найденная проекция</returns>
        
        TResult Query<TResult>( Func<IQueryable<T>, TResult> callback, bool noTracking = false);

        ///// <summary>
        ///// Запрос на получение постраничного вывода сущностей из контекста
        ///// Работает только с заданным условием сортировки
        ///// </summary>
        ///// <param name="pageNumber">Номер страницы (начинается с 1)</param>
        ///// <param name="pageSize">Количество записей на странице (минимальное 1)</param>
        ///// <param name="filter">Условие отбора сущностей</param>
        ///// <param name="orderBy">Условие сортировки</param>
        ///// <param name="include">Сущности включаемые в результат запроса</param>
        ///// <returns>Найденные сущности</returns>
        
        //IPagedList<T> Paged(int pageNumber, int pageSize,
        //     Expression<Func<T, bool>> filter,
        //     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        //    params Expression<Func<T, object>>[] include);

        //#region Methods immediately executed, pass by tracking system

        ///// <summary>
        ///// Удалить сущности по условию в контексте.
        ///// Метод выполняется немедленно, минуя систему трекинга.
        ///// Изменения не будут отражаться на сущностях в текущем контексте.
        ///// </summary>
        ///// <param name="filter">Условие отбора сущностей для удаления</param>
        ///// <returns>Количество удаленных объектов</returns>
        //int DeleteImmediately( Expression<Func<T, bool>> filter);

        ///// <summary>
        ///// Обновить сущности по условию в контексте.
        ///// Метод выполняется немедленно, минуя систему трекинга.
        ///// Изменения не будут отражаться на сущностях в текущем контексте.
        ///// </summary>
        ///// <param name="filter">Условие отбора сущностей для обновления</param>
        ///// <param name="updater">Выражение указывает, какие поля необходимо обновить</param>
        ///// <returns>Количество обновленных объектов</returns>
        //int UpdateImmediately( Expression<Func<T, bool>> filter,  Expression<Func<T, T>> updater, int EditorId);

        //#endregion
    }
}
