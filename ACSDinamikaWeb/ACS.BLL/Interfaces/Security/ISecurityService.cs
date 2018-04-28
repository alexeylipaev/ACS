using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface ISecurityService
    {
        //void GetRoles(AccessDTO accessDTO, string authorEmail);

        IEnumerable<ApplicationRoleDTO> Find(Func<ApplicationRoleDTO, Boolean> predicate);

        bool IsUserInRole(string userEmail, string roleName);

        void UpdateAccess(AccessDTO accessDTO, string authorEmail);

        AccessDTO GetAccess(int? Id);

        EmployeeDTO GetUser(int? Id);

        IEnumerable<AccessDTO> GetAccesses();

        void Dispose();
    }
}
