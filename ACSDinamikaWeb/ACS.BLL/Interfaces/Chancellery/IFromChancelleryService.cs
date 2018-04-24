using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
   public interface IFromChancelleryService
    {
        void MakeFromChancellery(FromChancelleryDTO FromChancelleryDTO);
        FromChancelleryDTO GetFromChancellery(int? id);
        IEnumerable<FromChancelleryDTO> GetFromChancellery();
        void Dispose();
    }
}
