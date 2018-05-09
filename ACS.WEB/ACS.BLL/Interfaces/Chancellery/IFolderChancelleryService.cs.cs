using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IFolderChancelleryService : IDisposable
    {
        void CreateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail);

        void UpdateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail);

        FolderChancelleryDTO GetFolderChancellery(int? id);
        IEnumerable<FolderChancelleryDTO> GetFoldersChancellery();

    }
}
