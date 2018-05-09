using ACS.DAL.Interfaces;
using ACS.DAL.Entities;
using EntityFramework.Extensions;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using ACS.DAL.EF;

namespace ACS.DAL.Repositories
{

  
    /// <summary>
    /// Класс репозитория для сущности типа {T}
    /// </summary>
    /// <typeparam name="T">Cущность доменной модели</typeparam>
    public class Repository<T> : RepositoryBase, IRepository<T>
        where T : class
    {
        public Repository(ACSContext dbContext)
            : base(dbContext)
        {
        }

        protected virtual DbSet<T> DbSet
        {
            get { return DbContext.Set<T>(); }
        }

        #region IRepository<T> Members

        public Type ObjectType
        {
            get { return typeof(T); }
        }

        public IList<T> GetAll(bool noTracking = false)
        {
            if (!noTracking)
            {
                return DbSet.ToList();
            }
            else
            {
                return DbSet.AsNoTracking().ToList();
            }
        }

        public T Find(params object[] id)
        {
            return DbSet.Find(id);
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }
        public int Add(T entity, int EditorId)
        {
            LastEdit<T>.SetData(ref entity, EditorId);
            DbSet.Add(entity);

            return DbContext.SaveChanges();
        }

        public int AddRange(IEnumerable<T> entities, int EditorId)
        {
            LastEdit<T>.SetData(ref entities, EditorId);
            DbSet.AddRange(entities);

            return DbContext.SaveChanges();
        }

        public int AddOrUpdate(T entity, int EditorId)
        {
            LastEdit<T>.SetData(ref entity, EditorId);
            DbSet.AddOrUpdate(entity);

            return DbContext.SaveChanges();
        }

        public int AddOrUpdate(T[] entities, int EditorId)
        {
            LastEdit<T>.SetData(ref entities, EditorId);
            DbSet.AddOrUpdate(entities);

            return DbContext.SaveChanges();
        }

        public int AddOrUpdate(T entity, Expression<Func<T, object>> identifier, int EditorId)
        {
            LastEdit<T>.SetData(ref entity, EditorId);
            DbSet.AddOrUpdate(identifier, entity);

            return DbContext.SaveChanges();
        }

        public int AddOrUpdate(T[] entities, Expression<Func<T, object>> identifier, int EditorId)
        {

            LastEdit<T>.SetData(ref entities, EditorId);
            DbSet.AddOrUpdate(identifier, entities);

            return DbContext.SaveChanges();
        }

        public int Update(T entity, int EditorId)
        {
            LastEdit<T>.SetData(ref entity, EditorId);

            DbContext.Entry(entity).State = EntityState.Modified;

            return DbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);

            return DbContext.SaveChanges();
        }

        public int Delete(params object[] id)
        {
            T entity = Find(id);

            if (entity == null)
                return 0;

            DbSet.Remove(entity);

            return DbContext.SaveChanges();
        }

        public int DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                DbSet.Attach(entity);
            }

            DbSet.RemoveRange(entities);

            return DbContext.SaveChanges();
        }

        public int DeleteAll(Expression<Func<T, bool>> filter)
        {
            DbSet.RemoveRange(DbSet.Where(filter).ToList());

            return DbContext.SaveChanges();
        }

        public long Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.LongCount();
        }

        public IList<T> Query(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool noTracking = false,
            params Expression<Func<T, object>>[] include
            )
        {
            IQueryable<T> query = DbSet;

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                foreach (var includeExpression in include)
                {
                    query = query.Include(includeExpression);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IList<T> Query(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                foreach (var includeExpression in include)
                {
                    query = query.Include(includeExpression);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IList<T> Query(
            Expression<Func<T, bool>> filter,
            bool noTracking = false,
            params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = DbSet;

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                foreach (var includeExpression in include)
                {
                    query = query.Include(includeExpression);
                }
            }

            return query.ToList();
        }

        public IList<T> Query(
            Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                foreach (var includeExpression in include)
                {
                    query = query.Include(includeExpression);
                }
            }

            return query.ToList();
        }


        public T Query(Func<IQueryable<T>, T> callback, bool noTracking = false)
        {
            IQueryable<T> query = DbSet;

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            return callback(query);
        }


        public TResult Query<TResult>(Func<IQueryable<T>, TResult> callback, bool noTracking = false)
        {
            IQueryable<T> query = DbSet;

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            return callback(query);
        }


        //public IPagedList<T> Paged(int pageNumber, int pageSize,
        //    Expression<Func<T, bool>> filter,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        //    params Expression<Func<T, object>>[] include)
        //{
        //    IQueryable<T> query = DbSet.AsNoTracking();

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    if (include != null)
        //    {
        //        foreach (var includeExpression in include)
        //        {
        //            query = query.Include(includeExpression);
        //        }
        //    }

        //    return orderBy(query).ToPagedList(pageNumber, pageSize);
        //}

        #endregion

        #region Methods immediately executed, pass by tracking system

        public int DeleteImmediately(Expression<Func<T, bool>> filter)
        {
            return DbSet.Where(filter).Delete();
        }

        public int UpdateImmediately(Expression<Func<T, bool>> filter, Expression<Func<T, T>> updater, int EditorId)
        {

            return DbSet.Where(filter).Update(updater);
        }

        #endregion
    }
    static public class LastEdit<T> where T : class
    {
        static public void SetData(ref T entity, int EditorId)
        {
            var sysparam = (entity as SystemParameters);
            if (sysparam != null)
            {
                sysparam.s_EditorId = EditorId;
                sysparam.s_EditDate = DateTime.Now;
            }

        }
        static public void SetData(ref IEnumerable<T> entities, int EditorId)
        {
            foreach (var Entity in entities)
            {
                var entity = Entity;
                SetData(ref entity, EditorId);
            }
        }
        static public void SetData(ref T[] entities, int EditorId)
        {
            foreach (var Entity in entities)
            {
                var entity = Entity;
                SetData(ref entity, EditorId);
            }
        }
    }
}
