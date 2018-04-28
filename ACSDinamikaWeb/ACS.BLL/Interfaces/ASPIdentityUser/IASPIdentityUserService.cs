using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IASPIdentityUserService
    {
        void MakeASPIdentityUser(ApplicationUserDTO ASPIdentityUserDTO);
        ApplicationUserDTO GetASPIdentityUser(int? Id);
        IEnumerable<ApplicationUserDTO> GetASPIdentityUser();
        void Dispose();
    }
}
