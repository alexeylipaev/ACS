using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IAccessService
    {
        void MakeAccess(AccessDTO AccessDTO);
        AccessDTO GetAccess(int? id);
        IEnumerable<AccessDTO> GetAccesses();
        void Dispose();
    }
}
