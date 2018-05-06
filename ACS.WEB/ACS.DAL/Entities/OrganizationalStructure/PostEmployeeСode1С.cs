using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Код1С должности 
    /// </summary>
    public partial class PostEmployeeСode1С : SystemParameters
    {
        public int id { get; set; }

        public Guid CodePost1C { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
