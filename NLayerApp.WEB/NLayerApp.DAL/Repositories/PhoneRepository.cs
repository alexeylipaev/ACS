using System;
using System.Collections.Generic;
using System.Linq;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using System.Data.Entity;
using JetBrains.Annotations;
using PagedList;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class PhoneRepository : IRepositoryAsync<Phone>
    {
        //private MobileContext db;

        //public PhoneRepository(MobileContext context)
        //{
        //    this.db = context;
        //}

        //public IEnumerable<Phone> GetAll()
        //{
        //    return db.Phones;
        //}

        //public Phone Get(int id)
        //{
        //    return db.Phones.Find(id);
        //}

        //public void Create(Phone book)
        //{
        //    db.Phones.Add(book);
        //}

        //public void Update(Phone book)
        //{
        //    db.Entry(book).State = EntityState.Modified;
        //}

        //public IEnumerable<Phone> Find(Func<Phone, Boolean> predicate)
        //{
        //    return db.Phones.Where(predicate).ToList();
        //}

        //public void Delete(int id)
        //{
        //    Phone book = db.Phones.Find(id);
        //    if (book != null)
        //        db.Phones.Remove(book);
        //}

        private IDbContextProvider dbContextProvider;
        //private IUnitOfWorkFactory unitOfWorkFactory;
        private IRepository<Phone> repositoryPhone;
        //private IRepository<Order> repositoryOrder;

        public PhoneRepository()
        {
            dbContextProvider = new ThreadDbContextProvider();
            //unitOfWorkFactory = new UnitOfWorkFactory(dbContextFactory, dbContextProvider);
            repositoryPhone = new Repository<Phone>(dbContextProvider);
            //repositoryOrder = new Repository<Order>(dbContextProvider);
        }


        public Type ObjectType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Add([NotNull] Phone entity)
        {
            throw new NotImplementedException();
        }

        public int AddOrUpdate([NotNull] Phone[] entities)
        {
            throw new NotImplementedException();
        }

        public int AddOrUpdate([NotNull] Phone entity)
        {
            throw new NotImplementedException();
        }

        public int AddOrUpdate([NotNull] Phone[] entities, Expression<Func<Phone, object>> identifier)
        {
            throw new NotImplementedException();
        }

        public int AddOrUpdate([NotNull] Phone entity, Expression<Func<Phone, object>> identifier)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddOrUpdateAsync([NotNull] Phone[] entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddOrUpdateAsync([NotNull] Phone[] entities, Expression<Func<Phone, object>> identifier)
        {
            throw new NotImplementedException();
        }

        public int AddRange([NotNull] IEnumerable<Phone> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync([NotNull] IEnumerable<Phone> entities)
        {
            throw new NotImplementedException();
        }

        public long Count([CanBeNull] Expression<Func<Phone, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync([CanBeNull] Expression<Func<Phone, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int Delete(params object[] id)
        {
            throw new NotImplementedException();
        }

        public int Delete([NotNull] Phone entity)
        {
           return repositoryPhone.Delete(entity.Id);
        }

        public int DeleteAll([NotNull] Expression<Func<Phone, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllAsync([NotNull] Expression<Func<Phone, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int DeleteImmediately([NotNull] Expression<Func<Phone, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteImmediatelyAsync([NotNull] Expression<Func<Phone, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int DeleteRange([NotNull] IEnumerable<Phone> entities)
        {
            throw new NotImplementedException();
        }

        public Phone Find(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task<Phone> FindAsync(params object[] id)
        {
            throw new NotImplementedException();
        }

        public IList<Phone> GetAll(bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<Phone>> GetAllAsync(bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Phone> Paged(int pageNumber, int pageSize, [CanBeNull] Expression<Func<Phone, bool>> filter, [NotNull] Func<IQueryable<Phone>, IOrderedQueryable<Phone>> orderBy, params Expression<Func<Phone, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<Phone>> PagedAsync(int pageNumber, int pageSize, [CanBeNull] Expression<Func<Phone, bool>> filter, [NotNull] Func<IQueryable<Phone>, IOrderedQueryable<Phone>> orderBy, params Expression<Func<Phone, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Phone Query([NotNull] Func<IQueryable<Phone>, Phone> callback, bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public IList<Phone> Query([CanBeNull] Expression<Func<Phone, bool>> filter, params Expression<Func<Phone, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public IList<Phone> Query([CanBeNull] Expression<Func<Phone, bool>> filter, bool noTracking = false, params Expression<Func<Phone, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public IList<Phone> Query([CanBeNull] Expression<Func<Phone, bool>> filter, [CanBeNull] Func<IQueryable<Phone>, IOrderedQueryable<Phone>> orderBy = null, params Expression<Func<Phone, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public IList<Phone> Query([CanBeNull] Expression<Func<Phone, bool>> filter, [CanBeNull] Func<IQueryable<Phone>, IOrderedQueryable<Phone>> orderBy = null, bool noTracking = false, params Expression<Func<Phone, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public TResult Query<TResult>([NotNull] Func<IQueryable<Phone>, TResult> callback, bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<Phone> QueryAsync([NotNull] Func<IQueryable<Phone>, Task<Phone>> callback, bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Phone>> QueryAsync([CanBeNull] Expression<Func<Phone, bool>> filter, params Expression<Func<Phone, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Phone>> QueryAsync([CanBeNull] Expression<Func<Phone, bool>> filter, bool noTracking = false, params Expression<Func<Phone, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Phone>> QueryAsync([CanBeNull] Expression<Func<Phone, bool>> filter, [CanBeNull] Func<IQueryable<Phone>, IOrderedQueryable<Phone>> orderBy = null, params Expression<Func<Phone, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Phone>> QueryAsync([CanBeNull] Expression<Func<Phone, bool>> filter, [CanBeNull] Func<IQueryable<Phone>, IOrderedQueryable<Phone>> orderBy = null, bool noTracking = false, params Expression<Func<Phone, object>>[] include)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> QueryAsync<TResult>([NotNull] Func<IQueryable<Phone>, Task<TResult>> callback, bool noTracking = false)
        {
            throw new NotImplementedException();
        }

        public int Update([NotNull] Phone entity)
        {
            throw new NotImplementedException();
        }

        public int UpdateImmediately([NotNull] Expression<Func<Phone, bool>> filter, [NotNull] Expression<Func<Phone, Phone>> updater)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateImmediatelyAsync([NotNull] Expression<Func<Phone, bool>> filter, [NotNull] Expression<Func<Phone, Phone>> updater)
        {
            throw new NotImplementedException();
        }
    }
}