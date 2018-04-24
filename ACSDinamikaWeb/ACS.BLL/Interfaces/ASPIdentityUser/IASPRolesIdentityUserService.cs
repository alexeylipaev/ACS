using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
   public interface IASPRolesIdentityUserService
    {
        void MakeASPRolesIdentityUser(ASPRolesIdentityUserDTO ASPRolesIdentityUserDTO);
        ASPRolesIdentityUserDTO GetASPRolesIdentityUser(int? id);
        IEnumerable<ASPRolesIdentityUserDTO> GetASPRolesIdentityUser();
        void Dispose();
    }
}
