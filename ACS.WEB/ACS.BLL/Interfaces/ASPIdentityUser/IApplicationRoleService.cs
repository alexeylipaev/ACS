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

        ApplicationRoleDTO FindById(int id);

        Task<OperationDetails> CreateAsync(ApplicationRoleDTO applicationRoleDTO);

        Task<ApplicationRoleDTO> FindByIdAsync(int id);

        IEnumerable<ApplicationRoleDTO> GetApplicationRoles();

        Task<OperationDetails> UpdateAsync(ApplicationRoleDTO applicationRoleDTO);

        Task<OperationDetails> DeleteAsync(int id);

    }
}
