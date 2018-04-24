using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
   public interface IChancelleryService
    {
        void MakeChancellery(ChancelleryDTO chancelleryDto);
        ChancelleryDTO GetChancellery(int? id);
        IEnumerable<ChancelleryDTO> GetChancelleries();
        void Dispose();
    }
}
