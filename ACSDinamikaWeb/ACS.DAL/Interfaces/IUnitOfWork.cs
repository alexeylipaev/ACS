using ACS.DAL.Entities;
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
        IRepository<Access> Accesses { get; }
        IRepository<ASPClaimsIdentityUser> ASPClaimsIdentityUsers { get; }
        IRepository<ASPIdentityUser> ASPIdentityUsers { get; }
        IRepository<ASPLoginsIdentityUser> ASPLoginsIdentityUsers { get; }
        IRepository<ASPRolesIdentityUser> ASPRolesIdentityUsers { get; }
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
        IRepository<TypeAccess> TypeAccesses { get; }
        IRepository<TypeRecordChancellery> TypeRecordChancelleries { get; }
        IRepository<User> Users { get; }
        IRepository<WorkHistory> WorkHistories { get; }
        IRepository<UserPassport> PassportDataUsers { get; }

        void Save();
    }
}
