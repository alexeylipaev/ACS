using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Коды должностей 1С
    /// </summary>
    public partial class PostUserСode1С : SystemParameters
    {

        public int Id { get; set; }

        [Required]
        public Guid CodePost1C { get; set; }


        public virtual User User { get; set; }

    }
}
