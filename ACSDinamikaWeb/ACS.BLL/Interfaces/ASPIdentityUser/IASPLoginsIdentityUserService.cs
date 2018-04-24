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
         
        void MakeASPLoginsIdentityUser(ASPLoginsIdentityUserDTO ASPLoginsIdentityUserDTO);
        ASPLoginsIdentityUserDTO GetASPLoginsIdentityUser(int? id);
        IEnumerable<ASPLoginsIdentityUserDTO> GetASPLoginsIdentityUser();
        void Dispose();

}
}
