using ACS.DAL.EF;
using ACS.DAL.Entities;
using ACS.DAL.Entities.ASPIdentityUser;
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

        private AccessRepository AccessRepository;
        private ApplicationUsersRepository ApplicationUsersRepository;
        private ApplicationClaimsRepository ApplicationClaimsRepository;
        private ApplicationLoginsRepository ApplicationLoginsRepository;
        private ApplicationRolesRepository ApplicationRolesRepository;
        private ChancelleryRepository ChancelleryRepository;
        private DataEntityRepository DataEntityRepository;
        private DepartmentRepository DepartmentRepository;
        private ExternalOrganizationChancelleryRepository ExternalOrganizationChancelleryRepository;
        private FolderChancelleryRepository FolderChancelleryRepository;
        private FileRecordChancelleryRepository FileRecordChancelleryRepository;
        private FromChancelleryRepository FromChancelleryRepository;
        private JournalRegistrationsChancelleryRepository JournalRegistrationsChancelleryRepository;
        private PostNameUserRepository PostNameUserRepository;
        private PostUserСode1СRepository PostUserСode1СRepository;
        private ToChancelleryRepository ToChancelleryRepository;
        private TypeAccessRepository TypeAccessRepository;
        private TypeRecordChancelleryRepository TypeRecordChancelleryRepository;
        private UserRepository UserRepository;
        private WorkHistoryRepository WorkHistoryRepository;
        private UserPassportRepository UserPassportRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ACSContext(connectionString);

            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            UserRepository = new UserRepository(db);

        }


        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public IRepository<Access> Accesses
        {
            get
            {
                if (AccessRepository == null)
                    AccessRepository = new AccessRepository(db);
                return AccessRepository;
            }
        }
        //public IRepository<ApplicationUser> ApplicationUsersRepository
        //{
        //    get
        //    {
        //        if (ApplicationUsersRepository == null)
        //            ApplicationUsersRepository = new ApplicationUsersRepository(db);
        //        return ApplicationUsersRepository;
        //    }
        //}
        //public IRepository<ApplicationClaim> ApplicationClaimsRepository
        //{
        //    get
        //    {
        //        if (ApplicationClaimsRepository == null)
        //            ApplicationClaimsRepository = new ApplicationClaimsRepository(db);
        //        return ApplicationClaimsRepository;
        //    }
        //}
        //public IRepository<ApplicationLogin> ApplicationLoginsRepository
        //{
        //    get
        //    {
        //        if (ApplicationLoginsRepository == null)
        //            ApplicationLoginsRepository = new ApplicationLoginsRepository(db);
        //        return ApplicationLoginsRepository;
        //    }
        //}
        //public IRepository<ApplicationUser> ApplicationRolesRepository
        //{
        //    get
        //    {
        //        if (ApplicationRolesRepository == null)
        //            ApplicationRolesRepository = new ApplicationRolesRepository(db);
        //        return ApplicationRolesRepository;
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
        public IRepository<PostNameUser> PostUsers
        {
            get
            {
                if (PostNameUserRepository == null)
                    PostNameUserRepository = new PostNameUserRepository(db);
                return PostNameUserRepository;
            }
        }

        public IRepository<PostUserСode1С> PostUserСode1С
        {
            get
            {
                if (PostUserСode1СRepository == null)
                    PostUserСode1СRepository = new PostUserСode1СRepository(db);
                return PostUserСode1СRepository;
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

        public IRepository<User> Users
        {
            get
            {
                if (UserRepository == null)
                    UserRepository = new UserRepository(db);
                return UserRepository;
            }
        }

        public IRepository<WorkHistory> WorkHistories
        {
            get
            {
                if (WorkHistoryRepository == null)
                    WorkHistoryRepository = new WorkHistoryRepository(db);
                return WorkHistoryRepository;
            }
        }
        public IRepository<UserPassport> PassportDataUsers
        {
            get
            {
                if (UserPassportRepository == null)
                    UserPassportRepository = new UserPassportRepository(db);
                return UserPassportRepository;
            }
        }




        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

    }
}
