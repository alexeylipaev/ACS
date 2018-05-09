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
        //int CreateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail);

        int CreateOrUpdateJournal(JournalRegistrationsChancelleryDTO FolderChancelleryDTO, string authorEmail);

        //int UpdateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail);

        JournalRegistrationsChancelleryDTO GetJournal(int id);

        IEnumerable<ChancelleryDTO> GetChancelleriesInJournal(int folderId);

        IEnumerable<JournalRegistrationsChancelleryDTO> GetJournalsChancellery();

        int DeleteJournal(int id);
    }
}
