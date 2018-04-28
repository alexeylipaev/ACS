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
        void MakeASPClaimsIdentityUser(ApplicationClaimDTO ASPClaimsIdentityUserDTO);
        ApplicationClaimDTO GetASPClaimsIdentityUser(int? Id);
        IEnumerable<ApplicationClaimDTO> GetASPClaimsIdentityUser();
        void Dispose();
    }
}
