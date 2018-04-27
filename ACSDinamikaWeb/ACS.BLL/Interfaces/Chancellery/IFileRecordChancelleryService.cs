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
        void MakeFileRecordChancellery(FileRecordChancelleryDTO FileRecordChancelleryDto, string authorEmail);

        void UpdateFileRecordChancellery(FileRecordChancelleryDTO FileRecordChancelleryDto, string authorEmail);

        FileRecordChancelleryDTO GetFileRecordChancellery(int? Id);
        IEnumerable<FileRecordChancelleryDTO> GetFilesRecordChancellery();
        void Dispose();
    }
}
