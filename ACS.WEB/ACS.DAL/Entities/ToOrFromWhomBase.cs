using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
  public partial class ToOrFromWhomBase<T, OWNER> : Entity
    {
        public ToOrFromWhomBase(bool IsFrom)
        {
            this.IsFrom = IsFrom;
        }
        public int id { get; set; }
        public int ObjectId { get; set; }
        public virtual T Object { get; set; }

        public bool IsFrom { get; set; }

        public int OwnerId { get; set; }
        public virtual OWNER Owner { get; set; }
    }
}
