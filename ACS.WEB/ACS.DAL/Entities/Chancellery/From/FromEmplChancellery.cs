using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    public class FromEmplChancellery: Entity
    {
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int ChancelleryId { get; set; }
        public virtual Chancellery Chancellery { get; set; }
    }
}
