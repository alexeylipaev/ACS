using ACS.DAL.EF;
using ACS.DAL.Entities;
using ACS.DAL.Interfaces;
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

        private AccessRepository AccessRepository;
        private ASPIdentityUserRepository ASPIdentityUserRepository;
        private ASPClaimsIdentityUserRepository ASPClaimsIdentityUserRepository;
        private ASPLoginsIdentityUserRepository ASPLoginsIdentityUserRepository;
        private ASPRolesIdentityUserRepository ASPRolesIdentityUserRepository;
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
        public IRepository<ASPIdentityUser> ASPIdentityUsers
        {
            get
            {
                if (ASPIdentityUserRepository == null)
                    ASPIdentityUserRepository = new ASPIdentityUserRepository(db);
                return ASPIdentityUserRepository;
            }
        }
        public IRepository<ASPClaimsIdentityUser> ASPClaimsIdentityUsers
        {
            get
            {
                if (ASPClaimsIdentityUserRepository == null)
                    ASPClaimsIdentityUserRepository = new ASPClaimsIdentityUserRepository(db);
                return ASPClaimsIdentityUserRepository;
            }
        }
        public IRepository<ASPLoginsIdentityUser> ASPLoginsIdentityUsers
        {
            get
            {
                if (ASPLoginsIdentityUserRepository == null)
                    ASPLoginsIdentityUserRepository = new ASPLoginsIdentityUserRepository(db);
                return ASPLoginsIdentityUserRepository;
            }
        }
        public IRepository<ASPRolesIdentityUser> ASPRolesIdentityUsers
        {
            get
            {
                if (ASPRolesIdentityUserRepository == null)
                    ASPRolesIdentityUserRepository = new ASPRolesIdentityUserRepository(db);
                return ASPRolesIdentityUserRepository;
            }
        }
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

        public IRepository<TypeAccess> TypeAccesses
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
    }
}
