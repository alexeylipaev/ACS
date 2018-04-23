using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    [Table("PostUser")]
    public partial class PostNameUser : SystemParameters
    {
       
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
