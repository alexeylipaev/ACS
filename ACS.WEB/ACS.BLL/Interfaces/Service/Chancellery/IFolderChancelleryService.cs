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
        Task<int> CreateOrUpdateAsync(FolderCorrespondencesDTO FolderCorrespondencesDTO, string authorEmail);

        /// <summary>
        /// Удалить папку
        /// </summary>
        /// <param name="FolderCorrespondencesDTO"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(int id);

        Task<FolderCorrespondencesDTO> FindAsync(int id);

        /// <summary>
        /// Получить все папки
        /// </summary>
        /// <returns></returns>
       Task<IEnumerable<FolderCorrespondencesDTO>> GetAllAsync();

        /// <summary>
        /// Получить канцелярию в папке
        /// </summary>
        /// <param name="folderId"></param>
        /// <returns></returns>
        Task<IEnumerable<CorrespondencesBaseDTO>> GetChancelleryInFolderAsync(int folderId);

    }
}
