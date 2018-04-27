﻿using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IWorkHistoryService
    {
        void MakeWorkHistory(WorkHistoryDTO WorkHistoryDTO);
        WorkHistoryDTO GetWorkHistory(int? Id);
        IEnumerable<WorkHistoryDTO> GetWorkHistory();
        void Dispose();
    }
}
