using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    public class ChancelleryDTO : EntityDTO
    {
        #region simple prop
        public string RegistrationNumber { get; set; }
        public DateTime? DateRegistration { get; set; }
        public string Summary { get; set; }
        public string Notice { get; set; }
        public string Status { get; set; }

        #endregion
        public string Type { get; set; }
        public string Folder { get; set; }
        public string JournalRegistrations { get; set; }
        public IEnumerable<string> ResponsibleEmployees { get; set; }
        public IEnumerable<string> Files { get; set; }
        public IEnumerable<string> From { get; set; }
        public IEnumerable<string> To { get; set; }
    }
}