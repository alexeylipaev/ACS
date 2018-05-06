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
    public class EFUnitOfWork : IUnitOfWork
    {
        private ACSContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
      

        //private ApplicationUserRepository ApplicationUserRepository;

        //private ApplicationClaimRepository ApplicationClaimRepository;
        //private ApplicationLoginRepository ApplicationLoginRepository;
        //private ApplicationRoleRepository ApplicationRoleRepository;

        private ChancelleryRepository ChancelleryRepository;
        private DataEntityRepository DataEntityRepository;
        private DepartmentRepository DepartmentRepository;
        private ExternalOrganizationChancelleryRepository ExternalOrganizationChancelleryRepository;
        private FolderChancelleryRepository FolderChancelleryRepository;
        private FileRecordChancelleryRepository FileRecordChancelleryRepository;
        private FromChancelleryRepository FromChancelleryRepository;
        private JournalRegistrationsChancelleryRepository JournalRegistrationsChancelleryRepository;
        private PostNameEmployeeRepository PostNameUserRepository;
        private PostsEmployeesСode1СRepository PostsEmployeesСode1СRepository;
        private ToChancelleryRepository ToChancelleryRepository;
        private TypeAccessRepository TypeAccessRepository;
        private TypeRecordChancelleryRepository TypeRecordChancelleryRepository;

        private WorkHistoryRepository WorkHistoryRepository;
        private EmployeePassportRepository EmployeePassportRepository;
        private AccessRepository AccessRepository;

        private EmployeeRepository EmployeeRepository;



        public EFUnitOfWork(string connectionString)
        {
            db = new ACSContext(connectionString);

            userManager = new ApplicationUserManager(new AppUserStore(db));
            roleManager = new ApplicationRoleManager(new AppRoleStore(db));

            //ApplicationUserRepository = new ApplicationUserRepository(db);

        }



        public IRepository<Employee> Employees
        {
            get
            {
                if (EmployeeRepository == null)
                    EmployeeRepository = new EmployeeRepository(db);
                return EmployeeRepository;
            }
        }


        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        //public ApplicationSignInManager SignInManager
        //{
        //    get { return signInManager; }
        //}


        public IRepository<Access> Accesses
        {
            get
            {
                if (AccessRepository == null)
                    AccessRepository = new AccessRepository(db);
                return AccessRepository;
            }
        }

        //public IRepository<ApplicationUser> ApplicationUsers
        //{
        //    get
        //    {
        //        if (ApplicationUserRepository == null)
        //            ApplicationUserRepository = new ApplicationUserRepository(db);
        //        return ApplicationUserRepository;
        //    }
        //}
        //public IRepository<ApplicationClaim> ApplicationClaims
        //{
        //    get
        //    {
        //        if (ApplicationClaimRepository == null)
        //            ApplicationClaimRepository = new ApplicationClaimRepository(db);
        //        return ApplicationClaimRepository;
        //    }
        //}
        //public IRepository<ApplicationLogin> ApplicationLogins
        //{
        //    get
        //    {
        //        if (ApplicationLoginRepository == null)
        //            ApplicationLoginRepository = new ApplicationLoginRepository(db);
        //        return ApplicationLoginRepository;
        //    }
        //}
        //public IRepository<ApplicationRole> ApplicationRoles
        //{
        //    get
        //    {
        //        if (ApplicationRoleRepository == null)
        //            ApplicationRoleRepository = new ApplicationRoleRepository(db);
        //        return ApplicationRoleRepository;
        //    }
        //}

        public IRepository<Chancellery> Chancelleries
        {
            get
            {
                if (ChancelleryRepository == null)
                    ChancelleryRepository = new ChancelleryRepository(db);
                return ChancelleryRepository;
            }
        }
        public IRepository<DataEntity> DataEntityis
        {
            get
            {
                if (DataEntityRepository == null)
                    DataEntityRepository = new DataEntityRepository(db);
                return DataEntityRepository;
            }
        }
        public IRepository<Department> Departments
        {
            get
            {
                if (DepartmentRepository == null)
                    DepartmentRepository = new DepartmentRepository(db);
                return DepartmentRepository;
            }
        }
        public IRepository<ExternalOrganizationChancellery> ExternalOrganizationChancelleries
        {
            get
            {
                if (ExternalOrganizationChancelleryRepository == null)
                    ExternalOrganizationChancelleryRepository = new ExternalOrganizationChancelleryRepository(db);
                return ExternalOrganizationChancelleryRepository;
            }
        }
        public IRepository<FileRecordChancellery> FileRecordChancelleries
        {
            get
            {
                if (FileRecordChancelleryRepository == null)
                    FileRecordChancelleryRepository = new FileRecordChancelleryRepository(db);
                return FileRecordChancelleryRepository;
            }
        }
        public IRepository<FolderChancellery> FolderChancelleries
        {
            get
            {
                if (FolderChancelleryRepository == null)
                    FolderChancelleryRepository = new FolderChancelleryRepository(db);
                return FolderChancelleryRepository;
            }
        }
        public IRepository<FromChancellery> FromChancelleries
        {
            get
            {
                if (FromChancelleryRepository == null)
                    FromChancelleryRepository = new FromChancelleryRepository(db);
                return FromChancelleryRepository;
            }
        }
        public IRepository<JournalRegistrationsChancellery> JournalRegistrationsChancelleries
        {
            get
            {
                if (JournalRegistrationsChancelleryRepository == null)
                    JournalRegistrationsChancelleryRepository = new JournalRegistrationsChancelleryRepository(db);
                return JournalRegistrationsChancelleryRepository;
            }
        }
        public IRepository<PostNameEmployee> PostsEmployees
        {
            get
            {
                if (PostNameUserRepository == null)
                    PostNameUserRepository = new PostNameEmployeeRepository(db);
                return PostNameUserRepository;
            }
        }

        public IRepository<PostEmployeeСode1С> PostsEmployeesСode1С
        {
            get
            {
                if (PostsEmployeesСode1СRepository == null)
                    PostsEmployeesСode1СRepository = new PostsEmployeesСode1СRepository(db);
                return PostsEmployeesСode1СRepository;
            }
        }

        public IRepository<ToChancellery> ToChancelleries
        {
            get
            {
                if (ToChancelleryRepository == null)
                    ToChancelleryRepository = new ToChancelleryRepository(db);
                return ToChancelleryRepository;
            }
        }

        public IRepository<TypeAccess> TypesAccesses
        {
            get
            {
                if (TypeAccessRepository == null)
                    TypeAccessRepository = new TypeAccessRepository(db);
                return TypeAccessRepository;
            }
        }

        public IRepository<TypeRecordChancellery> TypeRecordChancelleries
        {
            get
            {
                if (TypeRecordChancelleryRepository == null)
                    TypeRecordChancelleryRepository = new TypeRecordChancelleryRepository(db);
                return TypeRecordChancelleryRepository;
            }
        }

        //public IRepository<Employee> Employees
        //{
        //    get
        //    {
        //        if (EmployeeRepository == null)
        //            EmployeeRepository = new EmployeeRepository(db);
        //        return EmployeeRepository;
        //    }
        //}

        public IRepository<WorkHistory> WorkHistories
        {
            get
            {
                if (WorkHistoryRepository == null)
                    WorkHistoryRepository = new WorkHistoryRepository(db);
                return WorkHistoryRepository;
            }
        }
        public IRepository<EmployeePassport> EmployeesPassports
        {
            get
            {
                if (EmployeePassportRepository == null)
                    EmployeePassportRepository = new EmployeePassportRepository(db);
                return EmployeePassportRepository;
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
                    //ApplicationUserRepository.Dispose();
                }
                this.disposed = true;
            }
        }

    }
}
