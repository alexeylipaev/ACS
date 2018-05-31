using ACS.BLL.Interfaces;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;

namespace ACS.BLL.Services
{
  public  class ExternalOrganizationService : ServiceBase, IExternalOrganizationService
    {
        public ExternalOrganizationService(IUnitOfWork uow) : base(uow) { }

        public async Task<int> CreateOrUpdateAsync(ExternalOrganizationDTO externalOrganizationDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var extlOrg = Database.ExternalOrganization.Find(externalOrganizationDTO.Id);
                extlOrg =  MapExtlOrg.ExtlOrgDTOToExtlOrg(externalOrganizationDTO);
                extlOrg.s_EditorId = AuthorID;
                extlOrg.s_EditDate = DateTime.Now;
                return await Database.ExternalOrganization.AddOrUpdateAsync(extlOrg, AuthorID);
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await Database.ExternalOrganization.DeleteAsync(id);
        }

       
        public async Task<ExternalOrganizationDTO> FindAsync(int id)
        {
            var result = await Database.ExternalOrganization.FindAsync(id);

            return MapExtlOrg.ExtlOrgToExtlOrgDto(result);
        }

        public async Task<IEnumerable<ExternalOrganizationDTO>> GetAllAsync()
        {
            var resultList = await Database.ExternalOrganization.GetAllAsync();
            return MapExtlOrg.ListExtlOrgToListextlOrgDto(resultList);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
