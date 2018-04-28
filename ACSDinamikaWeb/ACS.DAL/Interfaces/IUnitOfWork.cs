using ACS.DAL.Entities;
using ACS.DAL.Entities.ASPIdentityUser;
using ACS.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Interfaces
{
    /// <summary>
    /// pattern Unit Of Work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Данный класс будет управлять пользователями: добавлять их в базу данных и аутентифицировать.
        /// </summary>
        ApplicationUserManager UserManager { get; }

        ApplicationRoleManager RoleManager { get; }

        IRepository<Access> Accesses { get; }
        IRepository<ApplicationClaim> ApplicationClaimsRepository { get; }
        IRepository<ApplicationUser> ApplicationUsersRepository { get; }
        IRepository<ApplicationLogin> ApplicationLoginsRepository { get; }
        IRepository<ApplicationRole> ApplicationRolesRepository { get; }
        IRepository<Chancellery> Chancelleries { get; }
        IRepository<DataEntity> DataEntityis { get; }
        IRepository<Department> Departments { get; }
        IRepository<ExternalOrganizationChancellery> ExternalOrganizationChancelleries { get; }
        IRepository<FileRecordChancellery> FileRecordChancelleries { get; }
        IRepository<FolderChancellery> FolderChancelleries { get; }
        IRepository<FromChancellery> FromChancelleries { get; }
        IRepository<JournalRegistrationsChancellery> JournalRegistrationsChancelleries { get; }
        IRepository<PostNameUser> PostUsers { get; }
        IRepository<PostUserСode1С> PostUserСode1С { get; }
        IRepository<ToChancellery> ToChancelleries { get; }
        IRepository<TypeAccess> TypesAccesses { get; }
        IRepository<TypeRecordChancellery> TypeRecordChancelleries { get; }
        IRepository<User> Users { get; }
        IRepository<WorkHistory> WorkHistories { get; }
        IRepository<UserPassport> PassportDataUsers { get; }

        void Save();

        Task SaveAsync();
    }
}
