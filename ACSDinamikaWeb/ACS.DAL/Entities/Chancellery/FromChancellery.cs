using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{

    /// <summary>
    /// От кого
    /// </summary>
    public partial class FromChancellery : SystemParameters
    {
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? FromGuid { get; set; }

        /// <summary>
        /// Id объекта, где искать объект
        /// </summary>
        public int? TableId { get; set; }

        public virtual Chancellery Chancellery { get; set; }
    }
}
