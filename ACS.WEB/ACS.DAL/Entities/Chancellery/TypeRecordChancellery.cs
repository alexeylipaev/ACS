using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Тип канцелярской записи
    /// </summary>
    public partial class TypeRecordChancellery : SystemParameters
    {
        public TypeRecordChancellery()
        {
            Chancelleries = new HashSet<Chancellery>();
        }
 
        public byte Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Канцелярские записи которые имеют this тип
        /// </summary>
        public virtual ICollection<Chancellery> Chancelleries { get; set; }
    }
}
