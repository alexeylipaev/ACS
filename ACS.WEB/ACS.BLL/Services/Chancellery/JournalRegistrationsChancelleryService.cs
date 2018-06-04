using ACS.BLL.Interfaces;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using ACS.DAL.Entities;

namespace ACS.BLL.Services
{
    public class JournalRegistrationsChancelleryService : ServiceBase, IJournalRegistrationsChancelleryService
    {
        public JournalRegistrationsChancelleryService(IUnitOfWork uow) : base(uow) { }

        public async Task<int> CreateOrUpdateAsync(JournalRegistrationsCorrespondencesDTO journalCorrespondencesDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var journal = Database.JournalRegistrationsChancelleries.Find(journalCorrespondencesDTO.Id);
                journal = await MapChancellery.JournalDTOToJournal(journalCorrespondencesDTO);
                InitSystemData<JournalRegistrationsChancellery>.Init(ref journal, AuthorID);
                return await Database.JournalRegistrationsChancelleries.AddOrUpdateAsync(journal);
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await Database.JournalRegistrationsChancelleries.DeleteAsync(id);
        }



        public async Task<JournalRegistrationsCorrespondencesDTO> FindAsync(int id)
        {
            var result = await Database.JournalRegistrationsChancelleries.FindAsync(id);

            return MapChancellery.JournalToJournalDTO(result);
        }

        public async Task<IEnumerable<JournalRegistrationsCorrespondencesDTO>> GetAllAsync()
        {
            var resultList = await Database.JournalRegistrationsChancelleries.GetAllAsync();
            return MapChancellery.ListJournalToListJournalDto(resultList);
        }


        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<IEnumerable<CorrespondencesBaseDTO>> GetChancelleriesInJournalAsync(int journalId)
        {
            throw new NotImplementedException();
        }
    }
}
