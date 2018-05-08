using NLayerApp.DAL.Interfaces;
using JetBrains.Annotations;
using System.Data.Entity;
using System.Monads;
using System.Transactions;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.EF.Exceptions;
using NLayerApp.DAL.Entities;
using System;

namespace NLayerApp.DAL.Repositories
{
    /// <summary>
    /// Единица работы
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextProvider _dbContextProvider;
        private readonly MobileContext _dbContext;
        private readonly TransactionScope _transaction;

        private bool _wasCommitted = false;
        private bool _hasTransaction = false;
        private bool _isNested = false;

        private IRepository<Phone> repositoryPhone;
        private IRepository<Order> repositoryOrder;

        public IRepository<Phone> Phones
        {
            get
           {
               if (repositoryPhone == null)
                    repositoryPhone = new PhoneRepository();
               return repositoryPhone;
           }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (repositoryOrder == null)
                    repositoryOrder = new OrderRepository();
                return repositoryOrder;
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dbContextProvider">Провайдер сессии EntityFramework</param>
        /// <param name="dbContext">Сессия EntityFramework</param>
        /// <param name="isolationLevel">Уровень изоляции (задает поведение при блокировке транзакции для подключения)</param>
        public UnitOfWork([NotNull] IDbContextProvider dbContextProvider, [NotNull] MobileContext dbContext,
            IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            _dbContextProvider = dbContextProvider.CheckNull("dbContextProvider");
            _dbContext = dbContext.CheckNull("dbContext");

            _isNested = !_dbContextProvider.IsEmpty && Transaction.Current != null;

            if (!_isNested)
            {
                _dbContextProvider.CurrentDbContext = _dbContext;

                repositoryPhone = new Repository<Phone>(_dbContextProvider);
                repositoryOrder = new Repository<Order>(_dbContextProvider);

                if (Transaction.Current == null)
                {
                    _transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = isolationLevel });

                    _hasTransaction = true;
                }
            }
        }

        /// <summary>
        /// Сохранить ВСЕ изменения в базу
        /// </summary>
        public void Commit()
        {
            if (_wasCommitted)
            {
                throw new DalEFException(
                    "Для текущей сессии уже был вызван Commit." +
                    "Пожалуйста, откройте новый сеанс через UnitOfWorkFactory.");
            }

            ExceptionWrapper.WrapCall(() =>
            {
                _dbContext.SaveChanges();

                if (!_isNested)
                {
                    if (_hasTransaction)
                    {
                        _transaction.Complete();
                    }

                    _dbContextProvider.CurrentDbContext = null;
                }
            });

            _wasCommitted = true;
        }
        public void Dispose()
        {
            if (!_isNested)
            {
                if (_hasTransaction)
                {
                    _transaction.Dispose();
                }

                _dbContextProvider.CurrentDbContext = null;
                _dbContext.Dispose();
            }
        }
    }
}
    //public class EFUnitOfWork : IUnitOfWork
    //{
    //    private MobileContext db;
    //    private PhoneRepository phoneRepository;
    //    private OrderRepository orderRepository;

    //    public EFUnitOfWork(string connectionString)
    //    {
    //        db = new MobileContext(connectionString);
    //    }
    //    public IRepository<Phone> Phones
    //    {
    //        get
    //        {
    //            if (phoneRepository == null)
    //                phoneRepository = new PhoneRepository(db);
    //            return phoneRepository;
    //        }
    //    }

    //    public IRepository<Order> Orders
    //    {
    //        get
    //        {
    //            if (orderRepository == null)
    //                orderRepository = new OrderRepository(db);
    //            return orderRepository;
    //        }
    //    }

    //    public void Save()
    //    {
    //        db.SaveChanges();
    //    }

    //    private bool disposed = false;

    //    public virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                db.Dispose();
    //            }
    //            this.disposed = true;
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //}
