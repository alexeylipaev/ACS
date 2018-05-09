using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface ITypeAccessService : IDisposable
    {

        void CreateTypeAccess(TypeAccessDTO TypeAccessDTO, string authorEmail);

        void UpdateChancellery(TypeAccessDTO TypeAccessDTO, string authorEmail);

        TypeAccessDTO GetTypeAccess(int? id);
        IEnumerable<TypeAccessDTO> GetTypesAccess();

    }

}
