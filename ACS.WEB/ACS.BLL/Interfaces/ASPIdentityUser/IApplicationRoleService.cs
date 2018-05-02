using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
   public interface IApplicationRoleService
    {
        void MakeApplicationRole(ApplicationRoleDTO ApplicationRolesDTO);
        ApplicationRoleDTO GetApplicationRole(int? Id);
        IEnumerable<ApplicationRoleDTO> GetApplicationRole();
        void Dispose();
    }
}
