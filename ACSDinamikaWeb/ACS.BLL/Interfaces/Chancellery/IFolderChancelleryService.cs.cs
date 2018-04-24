using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IFolderChancelleryService
    {
        void MakeFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO);
        FolderChancelleryDTO GetFolderChancellery(int? id);
        IEnumerable<FolderChancelleryDTO> GetFolderChancellery();
        void Dispose();
    }
}
