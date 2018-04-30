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

        //IEnumerable<ApplicationRoleDTO> Find(Func<ApplicationRoleDTO, Boolean> predicate);

        bool IsUserInRole(string userEmail, string roleName);


        //ApplicationUserDTO GetApplicationUser(int? Id);


        void Dispose();
    }
}
