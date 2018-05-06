using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IToChancelleryService : IDisposable
    {
        void MakeToChancellery(ToChancelleryDTO ToChancelleryDTO, string authorEmail);

        void UpdateToChancellery(ToChancelleryDTO ToChancelleryDTO, string authorEmail);

        ToChancelleryDTO GetToChancellery(int? id);
        IEnumerable<ToChancelleryDTO> GetToChancellery();
  
    }
}
