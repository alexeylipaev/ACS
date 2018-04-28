using ACS.DAL.Entities;

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
        //IRepository<ApplicationUser> ApplicationUsers{ get; }
        ApplicationRoleManager RoleManager { get; }

        //IRepository<ApplicationClaim> ApplicationClaims { get; }
        //IRepository<ApplicationLogin> ApplicationLogins{ get; }
        //IRepository<ApplicationRole> ApplicationRoles{ get; }

        IRepository<Employee> Employees { get; }
        IRepository<Access> Accesses { get; }
        IRepository<Chancellery> Chancelleries { get; }
        IRepository<DataEntity> DataEntityis { get; }
        IRepository<Department> Departments { get; }
        IRepository<ExternalOrganizationChancellery> ExternalOrganizationChancelleries { get; }
        IRepository<FileRecordChancellery> FileRecordChancelleries { get; }
        IRepository<FolderChancellery> FolderChancelleries { get; }
        IRepository<FromChancellery> FromChancelleries { get; }
        IRepository<JournalRegistrationsChancellery> JournalRegistrationsChancelleries { get; }
        IRepository<PostNameEmployee> PostsEmployees { get; }
        IRepository<PostsEmployeesСode1С> PostsEmployeesСode1С { get; }
        IRepository<ToChancellery> ToChancelleries { get; }
        IRepository<TypeAccess> TypesAccesses { get; }
        IRepository<TypeRecordChancellery> TypeRecordChancelleries { get; }

        IRepository<WorkHistory> WorkHistories { get; }
        IRepository<EmployeePassport> EmployeesPassports { get; }

        void Save();

        Task SaveAsync();
    }
}
