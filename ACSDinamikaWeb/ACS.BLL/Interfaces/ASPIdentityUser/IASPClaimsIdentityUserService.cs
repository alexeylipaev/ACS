using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IASPClaimsIdentityUserService
    {
        void MakeASPClaimsIdentityUser(ASPClaimsIdentityUserDTO ASPClaimsIdentityUserDTO);
        ASPClaimsIdentityUserDTO GetASPClaimsIdentityUser(int? Id);
        IEnumerable<ASPClaimsIdentityUserDTO> GetASPClaimsIdentityUser();
        void Dispose();
    }
}
