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

        int CreateOrUpdateTypeRecordChancellery(TypeRecordChancelleryDTO TypeRecordChancelleryDTO, string authorEmail);

        //int UpdateTypeRecordChancellery(TypeRecordChancelleryDTO TypeRecordChancelleryDTO, string authorEmail);

        TypeRecordChancelleryDTO GetTypeRecordChancellery(int id);

        IEnumerable<ChancelleryDTO> GetChancelleriesByType(int TypeRecordChancelleryId);

        IEnumerable<TypeRecordChancelleryDTO> GetTypesRecordChancellery();

        int DeleteTypeRecordChancellery(int id);

    }
}
