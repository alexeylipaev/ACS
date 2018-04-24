using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IJournalRegistrationsChancelleryService
    {
        void MakeJournalRegistrationsChancellery(JournalRegistrationsChancelleryDTO JournalRegistrationsChancelleryDto);
        JournalRegistrationsChancelleryDTO GetJournalRegistrationsChancellery(int? id);
        IEnumerable<JournalRegistrationsChancelleryDTO> GetChancelleries();
        void Dispose();
    }
}
