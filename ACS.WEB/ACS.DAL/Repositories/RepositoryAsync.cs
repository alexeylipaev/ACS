using ACS.DAL.Interfaces;
using ACS.DAL.Entities;

//using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ACS.DAL.EF;
using System.Data.Entity.Validation;
using ACS.DAL.Infrastructure;

namespace ACS.DAL.Repositories
{
    /// <summary>
    /// Класс асинхронного репозитория для сущности типа {T}
    /// </summary>
    /// <typeparam name="T">Cущность доменной модели</typeparam>
    public class RepositoryAsync<T> : Repository<T>, IRepositoryAsync<T>
        where T : class
    {

        public RepositoryAsync(ACSContext dbContext)
            : base(dbContext)
        {
        }
        public async Task<List<T>> ToListAsync(bool noTracking = false)
        {
            if (!noTracking)
            {
                return await DbSet.ToListAsync();
            }
            else
            {
                return await DbSet.AsNoTracking().ToListAsync();
            }
        }

        private async Task<int> SaveAsync(ACSContext DbContext)
        {
            try
            {
                return await DbContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                throw new DbEntitySaveValidationException(e);
            }
        }

        #region IRepositoryAsync<T> Members

        public async Task<List<T>> GetAllAsync(bool noTracking = false)
        {
            if (!noTracking)
            {
                return await DbSet.ToListAsync();
            }
            else
            {
                return await DbSet.AsNoTracking().ToListAsync();
            }
        }
  
        public async Task<T> FindAsync(params object[] id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<int> AddAsync(T entity, int EditorId)
        {
            LastEdit<T>.SetData(ref entity, EditorId);
            DbSet.Add(entity);

            return await SaveAsync(DbContext);
        }
        public async Task<int> AddRangeAsync(IEnumerable<T> entities, int EditorId)
        {
            LastEdit<T>.SetData(ref entities, EditorId);
            DbSet.AddRange(entities);

            return await SaveAsync(DbContext);
        }

        public async Task<int> AddOrUpdateAsync(T entity, int EditorId)
        {
            LastEdit<T>.SetData(ref entity, EditorId);
            DbSet.AddOrUpdate(entity);
            int i = entity.GetHashCode();
            return await SaveAsync(DbContext);
        }

        public async Task<int> AddOrUpdateAsync(T[] entities, int EditorId)
        {
            LastEdit<T>.SetData(ref entities, EditorId);
            DbSet.AddOrUpdate(entities);

          return await SaveAsync(DbContext);
        }

        public async Task<int> AddOrUpdateAsync(T[] entities, Expression<Func<T, object>> identifier, int EditorId)
        {
            LastEdit<T>.SetData(ref entities, EditorId);
            DbSet.AddOrUpdate(identifier, entities);

            return await SaveAsync(DbContext);
        }
        public async Task<int> UpdateAsync(T entity, int EditorId)
        {

            LastEdit<T>.SetData(ref entity, EditorId);

            DbContext.Entry(entity).State = EntityState.Modified;

            return await SaveAsync(DbContext);
        }
        public async Task<int> DeleteAsync(int id)
        {
        
            DbSet.Remove(await DbSet.FindAsync(id));

            return await SaveAsync(DbContext);
        }
        public async Task<int> DeleteAsync(T entity)
        {
            DbSet.Remove(entity);

            return await SaveAsync(DbContext);
        }
        public async Task<int> DeleteAllAsync(Expression<Func<T, bool>> filter)
        {
            DbSet.RemoveRange(await DbSet.Where(filter).ToListAsync());

            return await SaveAsync(DbContext);
        }

        public async Task<long> CountAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.LongCountAsync();
        }

        public async Task<IList<T>> QueryAsync(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
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

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<IList<T>> QueryAsync(
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
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<IList<T>> QueryAsync(
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

            return await query.ToListAsync();
        }

        public async Task<IList<T>> QueryAsync(
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

            return await query.ToListAsync();
        }

        public async Task<T> QueryAsync(Func<IQueryable<T>, Task<T>> callback, bool noTracking = false)
        {
            IQueryable<T> query = DbSet;

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            return await callback(query);
        }

        public async Task<TResult> QueryAsync<TResult>(Func<IQueryable<T>, Task<TResult>> callback, bool noTracking = false)
        {
            IQueryable<T> query = DbSet;

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            return await callback(query);
        }

        //public async Task<IPagedList<T>> PagedAsync(int pageNumber, int pageSize,
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

        //    var result = await orderBy(query).ToListAsync();

        //    return result.ToPagedList(pageNumber, pageSize);
        //}

        #endregion

        //#region Methods immediately executed, pass by tracking system

        //public async Task<int> DeleteImmediatelyAsync(Expression<Func<T, bool>> filter)
        //{
        //    return await DbSet.Where(filter).DeleteAsync();
        //}

        //public async Task<int> UpdateImmediatelyAsync(Expression<Func<T, bool>> filter, Expression<Func<T, T>> updater)
        //{
        //    return await DbSet.Where(filter).UpdateAsync(updater);
        //}

        //#endregion
    }
}