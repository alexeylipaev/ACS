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
        void CreateJournalRegistrationsChancellery(JournalRegistrationsChancelleryDTO JournalRegistrationsChancelleryDto, string authorEmail);

        void UpdateJournalRegistrationsChancellery(JournalRegistrationsChancelleryDTO JournalRegistrationsChancelleryDto, string authorEmail);

        JournalRegistrationsChancelleryDTO GetJournalRegistrationsChancellery(int? id);
        IEnumerable<JournalRegistrationsChancelleryDTO> GetJournalsRegistrationsChancellery();

    }
}
