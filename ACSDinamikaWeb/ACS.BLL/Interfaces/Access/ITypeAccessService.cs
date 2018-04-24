using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface ITypeAccessService
    {
        void MakeTypeAccess(TypeAccessDTO TypeAccessDTO);
        TypeAccessDTO GetTypeAccess(int? id);
        IEnumerable<TypeAccessDTO> GetTypeAccess();
        void Dispose();
    }

}
