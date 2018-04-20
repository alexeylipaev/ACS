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
        [DisplayFormat(NullDisplayText = @"Выберите тип")]
        public byte? TypeRecordId { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = @"Дата регистрации")]
        public DateTime? DateRegistration { get; set; }

        [StringLength(30)]
        [Display(Name = "Регистрационный номер")]
        public string RegistrationNumber { get; set; }

        [StringLength(1000)]
        [Display(Name = "Описание")]
        public string Summary { get; set; }

        

        public int? JournalRegistrationsId { get; set; }

        public int? FolderId { get; set; }

        public int? ResponsibleUserId { get; set; }

        public virtual FolderChancellery FolderChancellery { get; set; }

        public virtual JournalRegistrationsChancellery JournalRegistrationsChancellery { get; set; }

        
        [Display(Name = "Тип записи")]
        public virtual TypeRecordChancellery TypeRecordChancellery { get; set; }

        [Display(Name = "Ответственный")]
        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Файлы")]
        public virtual ICollection<FileRecordChancellery> FileRecordChancelleries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "От кого")]
        public virtual ICollection<FromChancellery> FromChancelleries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Кому")]
        public virtual ICollection<ToChancellery> ToChancelleries { get; set; }
    }
}
