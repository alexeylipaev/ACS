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
        void MakeTypeRecordChancellery(TypeRecordChancelleryDTO TypeRecordChancelleryDTO);
        TypeRecordChancelleryDTO GetTypeRecordChancellery(int? id);
        IEnumerable<TypeRecordChancelleryDTO> GetTypeRecordChancellery();
        void Dispose();
    }
}
