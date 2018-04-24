using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    public partial class TypeRecordChancelleryDTO : SystemParametersDTO
    {
        public TypeRecordChancelleryDTO()
        {
            Chancelleries = new HashSet<ChancelleryDTO>();
        }


        public byte Id { get; set; }

      
        public string Name { get; set; }

     
        public virtual ICollection<ChancelleryDTO> Chancelleries { get; set; }
    }
}
