namespace ACSWeb.Models.EF.CFFromDB
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
        [Display(Name = "���� �����������")]
        public DateTime? DateRegistration { get; set; }

        [StringLength(30)]
        [Display(Name = "��������������� �����")]
        public string RegistrationNumber { get; set; }

        [StringLength(1000)]
        [Display(Name = "��������")]
        public string Summary { get; set; }

        

        public int? JournalRegistrationsId { get; set; }

        public int? FolderId { get; set; }

        public int? ResponsibleUserId { get; set; }

        public virtual FolderChancellery FolderChancellery { get; set; }

        public virtual JournalRegistrationsChancellery JournalRegistrationsChancellery { get; set; }

        
        [Display(Name = "��� ������")]
        public virtual TypeRecordChancellery TypeRecordChancellery { get; set; }

        [Display(Name = "�������������")]
        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "�����")]
        public virtual ICollection<FileRecordChancellery> FileRecordChancelleries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "�� ����")]
        public virtual ICollection<FromChancellery> FromChancelleries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "����")]
        public virtual ICollection<ToChancellery> ToChancelleries { get; set; }
    }
}
