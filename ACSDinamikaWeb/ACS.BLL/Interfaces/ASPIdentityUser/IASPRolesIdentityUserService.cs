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
        void MakeASPRolesIdentityUser(ApplicationRolesDTO ApplicationRolesDTO);
        ApplicationRolesDTO GetASPRolesIdentityUser(int? Id);
        IEnumerable<ApplicationRolesDTO> GetASPRolesIdentityUser();
        void Dispose();
    }
}
