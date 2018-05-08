using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using JetBrains.Annotations;
using PagedList;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class OrderRepository : IRepositoryAsync<Order>
    {

        //private MobileContext db;

        //public OrderRepository(MobileContext context)
        //{
        //    this.db = context;
        //}

        //public IEnumerable<Order> GetAll()
        //{
        //    return db.Orders.Include(o => o.Phone);
        //}

        //public Order Get(int id)
        //{
        //    return db.Orders.Find(id);
        //}

        //public void Create(Order order)
        //{
        //    db.Orders.Add(order);
        //}

        //public void Update(Order order)
        //{
        //    db.Entry(order).State = EntityState.Modified;
        //}
        //public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        //{
        //    return db.Orders.Include(o => o.Phone).Where(predicate).ToList();
        //}
        //public void Delete(int id)
        //{
        //    Order order = db.Orders.Find(id);
        //    if (order != null)
        //        db.Orders.Remove(order);
        //}

        private IDbContextProvider dbContextProvider;
        //private IUnitOfWorkFactory unitOfWorkFactory;
        private IRepository<Phone> repositoryPhone;
        private IRepository<Order> repositoryOrder;

        public Type ObjectType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public OrderRepository()
        {
            dbContextProvider = new ThreadDbContextProvider();
            //unitOfWorkFactory = new UnitOfWorkFactory(dbContextFactory, dbContextProvider);
            repositoryPhone = new Repository<Phone>(dbContextProvider);
            repositoryOrder = new Repository<Order>(dbContextProvider);
        }

        public Task<List<Order>> GetAllAsync(bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<Order> FindAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync([NotNull] IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddOrUpdateAsync([NotNull] Order[] entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddOrUpdateAsync([NotNull] Order[] entities, Expression<Func<Order, object>> identifier)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllAsync([NotNull] Expression<Func<Order, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync([CanBeNull] Expression<Func<Order, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Order>> QueryAsync([CanBeNull] Expression<Func<Order, bool>> filter, [CanBeNull] Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null, bool noTracking = false, params Expression<Func<Order, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Order>> QueryAsync([CanBeNull] Expression<Func<Order, bool>> filter, [CanBeNull] Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null, params Expression<Func<Order, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Order>> QueryAsync([CanBeNull] Expression<Func<Order, bool>> filter, bool noTracking = false, params Expression<Func<Order, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Order>> QueryAsync([CanBeNull] Expression<Func<Order, bool>> filter, params Expression<Func<Order, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<Order> QueryAsync([NotNull] Func<IQueryable<Order>, Task<Order>> callback, bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> QueryAsync<TResult>([NotNull] Func<IQueryable<Order>, Task<TResult>> callback, bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<Order>> PagedAsync(int pageNumber, int pageSize, [CanBeNull] Expression<Func<Order, bool>> filter, [NotNull] Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy, params Expression<Func<Order, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetAll(bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public Order Find(params object[] id)
        {
            throw new NotImplementedException();
        }

        public int Add([NotNull] Order entity)
        {
            throw new NotImplementedException();
        }

        public int AddRange([NotNull] IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public int AddOrUpdate([NotNull] Order entity)
        {
            throw new NotImplementedException();
        }

        public int AddOrUpdate([NotNull] Order[] entities)
        {
            throw new NotImplementedException();
        }

        public int AddOrUpdate([NotNull] Order entity, Expression<Func<Order, object>> identifier)
        {
            throw new NotImplementedException();
        }

        public int AddOrUpdate([NotNull] Order[] entities, Expression<Func<Order, object>> identifier)
        {
            throw new NotImplementedException();
        }

        public int Update([NotNull] Order entity)
        {
            throw new NotImplementedException();
        }

        public int Delete([NotNull] Order entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(params object[] id)
        {
            throw new NotImplementedException();
        }

        public int DeleteRange([NotNull] IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll([NotNull] Expression<Func<Order, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public long Count([CanBeNull] Expression<Func<Order, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IList<Order> Query([CanBeNull] Expression<Func<Order, bool>> filter, [CanBeNull] Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null, bool noTracking = false, params Expression<Func<Order, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public IList<Order> Query([CanBeNull] Expression<Func<Order, bool>> filter, [CanBeNull] Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null, params Expression<Func<Order, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public IList<Order> Query([CanBeNull] Expression<Func<Order, bool>> filter, bool noTracking = false, params Expression<Func<Order, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public IList<Order> Query([CanBeNull] Expression<Func<Order, bool>> filter, params Expression<Func<Order, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Order Query([NotNull] Func<IQueryable<Order>, Order> callback, bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public TResult Query<TResult>([NotNull] Func<IQueryable<Order>, TResult> callback, bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Order> Paged(int pageNumber, int pageSize, [CanBeNull] Expression<Func<Order, bool>> filter, [NotNull] Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy, params Expression<Func<Order, object>>[] include)
        {
            throw new NotImplementedException();
        }
    }
}