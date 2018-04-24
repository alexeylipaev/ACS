using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{


    public partial class FromChancelleryDTO : SystemParametersDTO
    {
        public int Id { get; set; }


        public Guid? FromGuid { get; set; }


        public int? TableId { get; set; }

        public virtual ChancelleryDTO Chancellery { get; set; }
    }
}
