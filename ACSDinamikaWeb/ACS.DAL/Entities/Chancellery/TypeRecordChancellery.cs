using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    public partial class TypeRecordChancellery : SystemParameters
    {
        public TypeRecordChancellery()
        {
            Chancelleries = new HashSet<Chancellery>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Тип записи")]
        public string Name { get; set; }

     
        public virtual ICollection<Chancellery> Chancelleries { get; set; }
    }
}
