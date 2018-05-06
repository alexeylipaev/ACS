using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
   public interface IApplicationRoleService : IDisposable
    {


        int GetIdNewAppUser();

        AppUserRoleDTO GetAppUserRoleAssignmentData(int RoleId, int? UserId = null);

        ApplicationRoleDTO FindRoleById(int roleId);

        Task<OperationDetails> CreateAsync(ApplicationRoleDTO applicationRoleDTO);

        IEnumerable<ApplicationRoleDTO> GetApplicationRoles();

        void UpdateRole(ApplicationRoleDTO applicationRoleDTO);
     
        void DeleteRole(int roleId);

    }
}
