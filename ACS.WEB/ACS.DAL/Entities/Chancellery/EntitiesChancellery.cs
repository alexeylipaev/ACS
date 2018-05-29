using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    public partial class Chancellery : Entity
    {
        #region simple prop
        public string RegistrationNumber { get; set; }
        public DateTime? DateRegistration { get; set; }
        public string Summary { get; set; }
        public string Notice { get; set; }
        public string Status { get; set; }

        #endregion
        public int TypeRecordChancelleryId { get; set; }
        public virtual TypeRecordChancellery TypeRecordChancellery { get; set; }
        public int? FolderChancelleryId { get; set; }
        public virtual FolderChancellery FolderChancellery { get; set; }
        public int? JournalRegistrationsChancelleryId { get; set; }
        public virtual JournalRegistrationsChancellery JournalRegistrationsChancellery { get; set; }
        public virtual ICollection<Employee> ResponsibleEmployees { get; set; }
        public virtual ICollection<Files> FileRecordChancelleries { get; set; }

    }
    /// <summary>
    /// Тип канцелярской записи
    /// </summary>
    public partial class TypeRecordChancellery : Entity
    {
        public string Name { get; set; }

        /// <summary>
        /// Канцелярские записи которые имеют this тип
        /// </summary>
        public virtual ICollection<Chancellery> Chancelleries { get; set; }
    }

    /// <summary>
    /// Журнал канцелярский
    /// </summary>
    public partial class JournalRegistrationsChancellery : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Chancellery> Chancelleries { get; set; }
    }
    /// <summary>
    /// Канцелярская папка
    /// </summary>
    public partial class FolderChancellery : Entity
    {
        public string Name { get; set; }

        /// <summary>
        /// Канцелярские записи в папке
        /// </summary>
        public virtual ICollection<Chancellery> Chancelleries { get; set; }
    }
}
