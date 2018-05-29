using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IJournalRegistrationsChancelleryService : IDisposable
    {
        Task<int> CreateOrUpdateAsync(JournalRegistrationsCorrespondencesDTO journalCorrespondencesDTO, string authorEmail);
        Task<int> DeleteAsync(int id);
        Task<JournalRegistrationsCorrespondencesDTO> FindAsync(int id);
        Task<IEnumerable<JournalRegistrationsCorrespondencesDTO>> GetAllAsync();
        Task<IEnumerable<CorrespondencesBaseDTO>> GetChancelleriesInJournalAsync(int journalId);

      
    }
}
