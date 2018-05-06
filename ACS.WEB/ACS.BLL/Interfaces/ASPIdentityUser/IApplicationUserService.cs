using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{

    public interface IApplicationUserService : IDisposable
    {
        int GetIdNewAppUser();

        AppUserRoleDTO GetAppUserRoleAssignmentData(int RoleId, int? UserId = null);

        Task<ApplicationUserDTO> FindByNameAsync(string userName);

        Task<ApplicationUserDTO> FindByEmailAsync(string Email);

        ApplicationUserDTO FindByEmail(string Email);

        ApplicationRoleDTO FindRoleById(int roleId);

        ApplicationUserDTO FindById(int userId);

        Task<ApplicationUserDTO> FindByIdAsync(int userId);

        Task<OperationDetails> AddLoginAsync(int userId, UserLoginInfo login);

        Task<OperationDetails> CreateAsync(ApplicationUserDTO applicationUserDTO);

        Task<OperationDetails> AssignRolesAsync(int userId);

        IEnumerable<ApplicationUserDTO> GetApplicationUsers();

        IEnumerable<ApplicationRoleDTO> GetApplicationRoles();

        void UpdateUser(ApplicationUserDTO applicationUserDTO);

        void DeleteUser(int userId);
        bool IsInRole(string username, string roleName);
    }
}
