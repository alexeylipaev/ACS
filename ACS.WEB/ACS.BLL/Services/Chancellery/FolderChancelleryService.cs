using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using ACS.DAL.Interfaces;

namespace ACS.BLL.Services
{
    public class FolderChancelleryService : ServiceBase, IFolderChancelleryService
    {
        public FolderChancelleryService(IUnitOfWork uow) : base(uow) { }
        public async Task<int> CreateOrUpdateAsync(FolderCorrespondencesDTO FolderCorrespondencesDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var folder = Database.FolderChancelleries.Find(FolderCorrespondencesDTO.Id);
                folder = await MapChancellery.FolderDTOToFolder(FolderCorrespondencesDTO);
                return await Database.FolderChancelleries.AddOrUpdateAsync(folder, AuthorID);
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await Database.FolderChancelleries.DeleteAsync(id);
        }

 
        public async Task<FolderCorrespondencesDTO> FindAsync(int id)
        {
            var result = await Database.FolderChancelleries.FindAsync(id);

            return MapChancellery.FolderToFolderDTO(result);
        }

        public async Task<IEnumerable<FolderCorrespondencesDTO>> GetAllAsync()
        {
            var resultList = await Database.FolderChancelleries.GetAllAsync();
            return MapChancellery.ListFolderToListFolderDto(resultList);
        }

        public Task<IEnumerable<CorrespondencesBaseDTO>> GetChancelleryInFolderAsync(int folderId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
