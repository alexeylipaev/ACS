using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IFileRecordFileRecordChancelleryService
    {
        void MakeFileRecordChancellery(FileRecordChancelleryDTO FileRecordChancelleryDto);
        FileRecordChancelleryDTO GetFileRecordChancellery(int? id);
        IEnumerable<FileRecordChancelleryDTO> GetChancelleries();
        void Dispose();
    }
}
