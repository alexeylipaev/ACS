using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ACS.BLL.Interfaces
{
   public interface IFilesSevice : IDisposable
    {
        Task<int> CreateOrUpdateAsync(FilesDTO FilesDTO, string authorEmail);
        Task<int> DeleteAsync(int id);
        IEnumerable<FilesDTO> AddFiles(IEnumerable<HttpPostedFileBase> httpPostedFileBases);
        Task<FilesDTO> FindAsync(int id);
 
        Task<IEnumerable<FilesDTO>> GetAllFilesChancelleryAsync(CorrespondencesBaseDTO Chancellery);
        Task<FilesDTO> GetFileChancellerByPathAsync(string Path, int ChancelleryId);

    }
}
