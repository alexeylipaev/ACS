using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
   public interface IDataEntityService
    {
        void MakeDataEntity(DataEntityDTO DataEntityDTO);
        DataEntityDTO GetDataEntity(int? id);
        IEnumerable<DataEntityDTO> GetDataEntity();
        void Dispose();
    }
}
