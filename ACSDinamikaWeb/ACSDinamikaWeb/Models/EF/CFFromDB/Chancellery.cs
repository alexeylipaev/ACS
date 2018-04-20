namespace ACSDinamikaWeb.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chancellery")]
    public partial class Chancellery : SystemParameters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chancellery()
        {
            FileRecordChancelleries = new HashSet<FileRecordChancellery>();
            FromChancelleries = new HashSet<FromChancellery>();
            ToChancelleries = new HashSet<ToChancellery>();
        }

        public int Id { get; set; }

        public byte? TypeRecordId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateRegistration { get; set; }

        [StringLength(1000)]
        public string Summary { get; set; }

        [StringLength(30)]
        public string RegistrationNumber { get; set; }

        public int? JournalRegistrationsId { get; set; }

        public int? FolderId { get; set; }

        public int? ResponsibleUserId { get; set; }

        public virtual FolderChancellery FolderChancellery { get; set; }

        public virtual JournalRegistrationsChancellery JournalRegistrationsChancellery { get; set; }

        public virtual TypeRecordChancellery TypeRecordChancellery { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileRecordChancellery> FileRecordChancelleries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FromChancellery> FromChancelleries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToChancellery> ToChancelleries { get; set; }
    }
}
