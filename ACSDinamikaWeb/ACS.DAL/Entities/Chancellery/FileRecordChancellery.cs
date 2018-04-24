using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    
    public partial class FileRecordChancellery : SystemParameters
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(10)]
        public string format { get; set; }

        [Required]
        public string Path { get; set; }

        public virtual Chancellery Chancellery { get; set; }
    }
}
