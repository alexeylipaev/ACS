using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Канцелярская папка
    /// </summary>
    public partial class FolderChancellery : SystemParameters
    {

        public FolderChancellery()
        {
            Chancelleries = new HashSet<Chancellery>();
        }

        public int id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Канцелярские записи в папке
        /// </summary>
        public virtual ICollection<Chancellery> Chancelleries { get; set; }
    }
}
