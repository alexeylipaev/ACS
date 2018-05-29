
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

        ApplicationRoleManager RoleManager { get; }

       
        #region Chancellery

        IRepositoryAsync<Chancellery> Chancelleries { get; }

        IRepositoryAsync<FolderChancellery> FolderChancelleries { get; }
        IRepositoryAsync<JournalRegistrationsChancellery> JournalRegistrationsChancelleries { get; }
        IRepositoryAsync<TypeRecordChancellery> TypeRecordChancelleries { get; }

        #region To
        IRepositoryAsync<ToEmplChancellery> ToEmplsChancellery { get; }
        IRepositoryAsync<ToExtlOrgChancellery> ToExtlOrgsChancellery { get; }
        #endregion

        #region From
        IRepositoryAsync<FromEmplChancellery> FromEmplsChancellery { get; }
        IRepositoryAsync<FromExtlOrgChancellery> FromExtlOrgsChancellery { get; }
        #endregion

        #endregion

        IRepositoryAsync<ExternalOrganization> ExternalOrganization { get; }
        IRepositoryAsync<Files> Files { get; }
        IRepositoryAsync<Employee> Employees { get; }

        void Save();

        Task SaveAsync();
    }
}
