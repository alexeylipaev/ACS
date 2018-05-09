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
        //int CreateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail);

        int CreateOrUpdateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail);

        //int UpdateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail);

        FolderChancelleryDTO GetFolderChancellery(int id);

        IEnumerable<ChancelleryDTO> GetChancelleriesInForlder(int folderId);

        IEnumerable<FolderChancelleryDTO> GetFoldersChancellery();

        int DeleteFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO);

    }
}
