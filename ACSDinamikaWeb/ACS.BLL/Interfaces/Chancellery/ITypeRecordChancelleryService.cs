using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
   public interface ITypeRecordChancelleryService
    {
        void MakeTypeRecordChancellery(TypeRecordChancelleryDTO TypeRecordChancelleryDTO, string authorEmail);

        void UpdateTypeRecordChancellery(TypeRecordChancelleryDTO TypeRecordChancelleryDTO, string authorEmail);

        TypeRecordChancelleryDTO GetTypeRecordChancellery(int? Id);
        IEnumerable<TypeRecordChancelleryDTO> GetTypesRecordChancellery();
        void Dispose();
    }
}
