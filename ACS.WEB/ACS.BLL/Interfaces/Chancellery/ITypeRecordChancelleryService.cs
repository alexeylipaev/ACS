using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
   public interface ITypeRecordChancelleryService : IDisposable
    {
        void CreateTypeRecordChancellery(TypeRecordChancelleryDTO TypeRecordChancelleryDTO, string authorEmail);

        void UpdateTypeRecordChancellery(TypeRecordChancelleryDTO TypeRecordChancelleryDTO, string authorEmail);

        TypeRecordChancelleryDTO GetTypeRecordChancellery(int? id);
        IEnumerable<TypeRecordChancelleryDTO> GetTypesRecordChancellery();

    }
}
