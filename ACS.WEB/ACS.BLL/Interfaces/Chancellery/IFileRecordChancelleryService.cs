using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ACS.BLL.Interfaces
{
    public interface IFileRecordChancelleryService : IDisposable
    {
        //int CreateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail);

        int CreateOrUpdateFileRecord(FileRecordChancelleryDTO FileRecordChancelleryDTO, string authorEmail);

        IEnumerable<FileRecordChancelleryDTO> AddFiles(IEnumerable<HttpPostedFileBase> httpPostedFileBases);


        //int UpdateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail);

        FileRecordChancelleryDTO GetFileRecord(int id);

        //FileRecordChancelleryDTO DownloadFile(int id);

        //FileRecordChancelleryDTO OpenFileNewTab(int id);

        IEnumerable<FileRecordChancelleryDTO> GetFilesRecordChancellery();

        int DeleteFileRecord(int id);

    }
}
