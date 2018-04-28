using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IASPLoginsIdentityUserService
    {
         
        void MakeASPLoginsIdentityUser(ApplicationLoginDTO ASPLoginsIdentityUserDTO);
        ApplicationLoginDTO GetASPLoginsIdentityUser(int? Id);
        IEnumerable<ApplicationLoginDTO> GetASPLoginsIdentityUser();
        void Dispose();

}
}
