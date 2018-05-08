using ACS.DAL.EF;
using ACS.DAL.Entities;
using ACS.DAL.Identity;
using ACS.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Repositories
{
    /// <summary>
    /// Через EFUnitOfWork мы и будем взаимодействовать с базой данных.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private ACSContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;

        private IRepository<Chancellery> ChancelleryRepository;
        private IRepository<DataEntity> DataEntityRepository;
        private IRepository<Department> DepartmentRepository;
        private IRepository<ExternalOrganizationChancellery> ExternalOrganizationChancelleryRepository;
        private IRepository<FolderChancellery> FolderChancelleryRepository;
        private IRepository<FileRecordChancellery> FileRecordChancelleryRepository;
        private IRepository<FromChancellery> FromChancelleryRepository;
        private IRepository<JournalRegistrationsChancellery> JournalRegistrationsChancelleryRepository;
        private IRepository<PostNameEmployee> PostNameUserRepository;
        private IRepository<PostEmployeeСode1С> PostsEmployeesСode1СRepository;
        private IRepository<ToChancellery> ToChancelleryRepository;
        private IRepository<TypeAccess> TypeAccessRepository;

        private IRepository<TypeRecordChancellery> TypeRecordChancelleryRepository;
        private IRepository<WorkHistory> WorkHistoryRepository;
        private IRepository<EmployeePassport> EmployeePassportRepository;
        private IRepository<Access> AccessRepository;

        private IRepository<Employee> EmployeeRepository;



        public UnitOfWork(string connectionString)
        {
            db = new ACSContext(connectionString);

            userManager = new ApplicationUserManager(new AppUserStore(db));
            roleManager = new ApplicationRoleManager(new AppRoleStore(db));
        }
        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }


        public IRepository<Employee> Employees
        {
            get
            {
                if (EmployeeRepository == null)
                    EmployeeRepository = new Repository<Employee>(db);
                return EmployeeRepository;
            }
        }

        public IRepository<EmployeePassport> EmployeesPassports
        {
            get
            {
                if (EmployeePassportRepository == null)
                    EmployeePassportRepository = new Repository<EmployeePassport>(db);
                return EmployeePassportRepository;
            }
        }






        public IRepository<Access> Accesses
        {
            get
            {
                if (AccessRepository == null)
                    AccessRepository = new Repository<Access>(db);
                return AccessRepository;
            }
        }


        public IRepository<Chancellery> Chancelleries
        {
            get
            {
                if (ChancelleryRepository == null)
                    ChancelleryRepository = new Repository<Chancellery>(db);
                return ChancelleryRepository;
            }
        }
        public IRepository<DataEntity> DataEntityis
        {
            get
            {
                if (DataEntityRepository == null)
                    DataEntityRepository = new Repository<DataEntity>(db);
                return DataEntityRepository;
            }
        }
        public IRepository<Department> Departments
        {
            get
            {
                if (DepartmentRepository == null)
                    DepartmentRepository = new Repository<Department>(db);
                return DepartmentRepository;
            }
        }
        public IRepository<ExternalOrganizationChancellery> ExternalOrganizationChancelleries
        {
            get
            {
                if (ExternalOrganizationChancelleryRepository == null)
                    ExternalOrganizationChancelleryRepository = new Repository<ExternalOrganizationChancellery>(db);
                return ExternalOrganizationChancelleryRepository;
            }
        }
        public IRepository<FileRecordChancellery> FileRecordChancelleries
        {
            get
            {
                if (FileRecordChancelleryRepository == null)
                    FileRecordChancelleryRepository = new Repository<FileRecordChancellery>(db);
                return FileRecordChancelleryRepository;
            }
        }
        public IRepository<FolderChancellery> FolderChancelleries
        {
            get
            {
                if (FolderChancelleryRepository == null)
                    FolderChancelleryRepository = new Repository<FolderChancellery>(db);
                return FolderChancelleryRepository;
            }
        }
        public IRepository<FromChancellery> FromChancelleries
        {
            get
            {
                if (FromChancelleryRepository == null)
                    FromChancelleryRepository = new Repository<FromChancellery>(db);
                return FromChancelleryRepository;
            }
        }
        public IRepository<JournalRegistrationsChancellery> JournalRegistrationsChancelleries
        {
            get
            {
                if (JournalRegistrationsChancelleryRepository == null)
                    JournalRegistrationsChancelleryRepository = new Repository<JournalRegistrationsChancellery>(db);
                return JournalRegistrationsChancelleryRepository;
            }
        }
        public IRepository<PostNameEmployee> PostsEmployees
        {
            get
            {
                if (PostNameUserRepository == null)
                    PostNameUserRepository = new Repository<PostNameEmployee>(db);
                return PostNameUserRepository;
            }
        }

        public IRepository<PostEmployeeСode1С> PostsEmployeesСode1С
        {
            get
            {
                if (PostsEmployeesСode1СRepository == null)
                    PostsEmployeesСode1СRepository = new Repository<PostEmployeeСode1С>(db);
                return PostsEmployeesСode1СRepository;
            }
        }

        public IRepository<ToChancellery> ToChancelleries
        {
            get
            {
                if (ToChancelleryRepository == null)
                    ToChancelleryRepository = new Repository<ToChancellery>(db);
                return ToChancelleryRepository;
            }
        }

        public IRepository<TypeAccess> TypesAccesses
        {
            get
            {
                if (TypeAccessRepository == null)
                    TypeAccessRepository = new Repository<TypeAccess>(db);
                return TypeAccessRepository;
            }
        }

        public IRepository<TypeRecordChancellery> TypeRecordChancelleries
        {
            get
            {
                if (TypeRecordChancelleryRepository == null)
                    TypeRecordChancelleryRepository = new Repository<TypeRecordChancellery>(db);
                return TypeRecordChancelleryRepository;
            }
        }


        public IRepository<WorkHistory> WorkHistories
        {
            get
            {
                if (WorkHistoryRepository == null)
                    WorkHistoryRepository = new Repository<WorkHistory>(db);
                return WorkHistoryRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

    }
}
