using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Кому
    /// </summary>
    public partial class ToChancellery : SystemParameters
    {
        public int Id { get; set; }

        public Guid? ToGuid { get; set; }

        public int? TableId { get; set; }


        public virtual Chancellery Chancellery { get; set; }
    }
}
