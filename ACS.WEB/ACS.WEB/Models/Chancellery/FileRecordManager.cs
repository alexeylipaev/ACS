using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModel
{
    public class FileRecordManager
    {
        //public FileRecordManager(IEnumerable<FileRecordChancelleryViewModel> oldFileRecords)
        //{
        //    this.OldFileRecords = oldFileRecords.ToList();
        //    NewFiles = new List<HttpPostedFileBase>();
        //}
        public FileRecordManager()
        {
            this.OldFileRecords = new List<FileRecordChancelleryViewModel>();
           // NewFiles = new List<HttpPostedFileBase>();
        }
        public ICollection<FileRecordChancelleryViewModel> OldFileRecords { get; set; }

        //public ICollection<HttpPostedFileBase> NewFiles { get; set; }
    }
}