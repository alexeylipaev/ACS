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

        #region Chancellery

        private IRepositoryAsync<Chancellery> ChancelleryRepository;
        private IRepositoryAsync<FolderChancellery> FolderChancelleryRepository;
        private IRepositoryAsync<JournalRegistrationsChancellery> JournalRegistrationsChancelleryRepository;
        private IRepositoryAsync<TypeRecordChancellery> TypeRecordChancelleryRepository;

        #region To
        private IRepositoryAsync<ToEmplChancellery> ToEmplChancelleryRepository;
        private IRepositoryAsync<ToExtlOrgChancellery> ToExtlOrgChancelleryRepository;
        #endregion

        #region From
        private IRepositoryAsync<FromEmplChancellery> FromEmplChancelleryRepository;
        private IRepositoryAsync<FromExtlOrgChancellery> FromExtlOrgChancelleryRepository;
        #endregion

        #endregion

        private IRepositoryAsync<Files> FilesRepository;
        private IRepositoryAsync<ExternalOrganization> ExternalOrganizationRepository;
        private IRepositoryAsync<Employee> EmployeeRepository;

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

        #region Канцелярия 
        public IRepositoryAsync<Chancellery> Chancelleries
        {
            get
            {
                if (ChancelleryRepository == null)
                    ChancelleryRepository = new RepositoryAsync<Chancellery>(db);
                return ChancelleryRepository;
            }
        }
        public IRepositoryAsync<TypeRecordChancellery> TypeRecordChancelleries
        {
            get
            {
                if (TypeRecordChancelleryRepository == null)
                    TypeRecordChancelleryRepository = new RepositoryAsync<TypeRecordChancellery>(db);
                return TypeRecordChancelleryRepository;
            }
        }
        public IRepositoryAsync<FolderChancellery> FolderChancelleries
        {
            get
            {
                if (FolderChancelleryRepository == null)
                    FolderChancelleryRepository = new RepositoryAsync<FolderChancellery>(db);
                return FolderChancelleryRepository;
            }
        }

        public IRepositoryAsync<JournalRegistrationsChancellery> JournalRegistrationsChancelleries
        {
            get
            {
                if (JournalRegistrationsChancelleryRepository == null)
                    JournalRegistrationsChancelleryRepository = new RepositoryAsync<JournalRegistrationsChancellery>(db);
                return JournalRegistrationsChancelleryRepository;
            }
        }


        #region To
        public IRepositoryAsync<ToEmplChancellery> ToEmplsChancellery
        {
            get
            {
                if (ToEmplChancelleryRepository == null)
                    ToEmplChancelleryRepository = new RepositoryAsync<ToEmplChancellery>(db);
                return ToEmplChancelleryRepository;
            }
        }

        public IRepositoryAsync<ToExtlOrgChancellery> ToExtlOrgsChancellery
        {
            get
            {
                if (ToExtlOrgChancelleryRepository == null)
                    ToExtlOrgChancelleryRepository = new RepositoryAsync<ToExtlOrgChancellery>(db);
                return ToExtlOrgChancelleryRepository;
            }
        }


        #endregion

        #region From
        public IRepositoryAsync<FromEmplChancellery> FromEmplsChancellery
        {
            get
            {
                if (FromEmplChancelleryRepository == null)
                    FromEmplChancelleryRepository = new RepositoryAsync<FromEmplChancellery>(db);
                return FromEmplChancelleryRepository;
            }
        }

        public IRepositoryAsync<FromExtlOrgChancellery> FromExtlOrgsChancellery
        {
            get
            {
                if (FromExtlOrgChancelleryRepository == null)
                    FromExtlOrgChancelleryRepository = new RepositoryAsync<FromExtlOrgChancellery>(db);
                return FromExtlOrgChancelleryRepository;
            }
        }
        #endregion

        #endregion
        public IRepositoryAsync<Employee> Employees
        {
            get
            {
                if (EmployeeRepository == null)
                    EmployeeRepository = new RepositoryAsync<Employee>(db);
                return EmployeeRepository;
            }
        }

     
       
     
        public IRepositoryAsync<ExternalOrganization> ExternalOrganization
        {
            get
            {
                if (ExternalOrganizationRepository == null)
                    ExternalOrganizationRepository = new RepositoryAsync<ExternalOrganization>(db);
                return ExternalOrganizationRepository;
            }
        }
        public IRepositoryAsync<Files> Files
        {
            get
            {
                if (FilesRepository == null)
                    FilesRepository = new RepositoryAsync<Files>(db);
                return FilesRepository;
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
