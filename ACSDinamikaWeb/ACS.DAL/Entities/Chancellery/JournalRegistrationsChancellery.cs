using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Журнал канцелярский
    /// </summary>
    public partial class JournalRegistrationsChancellery : SystemParameters
    {

        public JournalRegistrationsChancellery()
        {
            Chancelleries = new HashSet<Chancellery>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public virtual ICollection<Chancellery> Chancelleries { get; set; }

    }
}
