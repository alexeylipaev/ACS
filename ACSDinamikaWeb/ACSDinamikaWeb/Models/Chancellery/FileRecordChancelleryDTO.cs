using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.Models
{
    
    public partial class FileRecordChancelleryViewModel : SystemParametersViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string format { get; set; }

        public string Path { get; set; }

        public virtual ChancelleryViewModel Chancellery { get; set; }
    }
}
