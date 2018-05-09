using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IWorkHistoryService : IDisposable
    {
        void CreateWorkHistory(WorkHistoryDTO WorkHistoryDTO);
        WorkHistoryDTO GetWorkHistory(int? id);
        IEnumerable<WorkHistoryDTO> GetWorkHistory();

    }
}
