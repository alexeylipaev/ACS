using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.Areas.Admin.Models
{
    /// <summary>
    /// Тип канцелярской записи
    /// </summary>
    public partial class TypeRecordChancelleryAdminVM : SystemParametersAdminVM
    {
        public TypeRecordChancelleryAdminVM()
        {
            //Chancelleries = new HashSet<ChancelleryDTO>();
        }


        public byte id { get; set; }

      
        public string Name { get; set; }

        /// <summary>
        /// Канцелярские записи которые имеют this тип
        /// </summary>
        //public virtual ICollection<ChancelleryDTO> Chancelleries { get; set; }
    }
}
