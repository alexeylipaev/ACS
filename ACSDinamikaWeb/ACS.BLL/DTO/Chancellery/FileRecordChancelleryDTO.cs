using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    
    public partial class FileRecordChancelleryDTO : SystemParametersDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string format { get; set; }

        public string Path { get; set; }

        public virtual ChancelleryDTO Chancellery { get; set; }
    }
}
