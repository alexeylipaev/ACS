using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IAccessService:IDisposable
    {
        void MakeAccess(AccessDTO accessDTO, string authorEmail);

        void UpdateAccess(AccessDTO accessDTO, string authorEmail);

        AccessDTO GetAccess(int? id);

        EmployeeDTO GetUser(int? id);

        IEnumerable<AccessDTO> GetAccesses();

    }
}
