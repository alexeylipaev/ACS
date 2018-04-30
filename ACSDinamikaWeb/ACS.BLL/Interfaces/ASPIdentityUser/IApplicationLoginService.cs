using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IApplicationLoginService
    {
         
        void MakeApplicationLogin(ApplicationLoginDTO ApplicationLoginDTO);
        ApplicationLoginDTO GetApplicationLogin(int? Id);
        IEnumerable<ApplicationLoginDTO> GetApplicationLogin();
        void Dispose();

}
}
