using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    [Table("DataTable")]
    public partial class DataEntity : SystemParameters
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column("object_id")]
        public int object_id { get; set; }

        [Column("type_desc")]
        public string type_desc { get; set; }


    }
}
