namespace ACSWeb.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User : SystemParameters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Accesses = new HashSet<Access>();
            ASPIdentityUsers = new HashSet<ASPIdentityUser>();
            Chancelleries = new HashSet<Chancellery>();
            PostUserСode1С = new HashSet<PostUserСode1С>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Имя")]
        public string FName { get; set; }

        [StringLength(30)]
        [Display(Name = "Фамилия")]
        public string LName { get; set; }

        [StringLength(25)]
        [Display(Name = "Отчество")]
        public string MName { get; set; }

        [Display(Name = "Табельный номер")]
        public int? PersonnelNumber { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата рождения")]
        public DateTime? Birthday { get; set; }

        [StringLength(6)]
        [Display(Name = "Серия документа")]
        public string PassportSeries { get; set; }

        [StringLength(8)]
        [Display(Name = "Номер документа")]
        public string PassportNumber { get; set; }

        [StringLength(25)]
        [Display(Name = "Кем выдан документ")]
        public string PassportIssuedBy { get; set; }

        [StringLength(6)]
        [Display(Name = "Код подразделения документа")]
        public string PassportUnitCode { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата выдачи документа")]
        public DateTime? PassportDateOfIssue { get; set; }

        [StringLength(50)]
        [Display(Name = "SID")]
        public string SID { get; set; }
        [Display(Name = "КодФизЛицо из 1С")]
        public Guid? Guid1C { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Access> Accesses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASPIdentityUser> ASPIdentityUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chancellery> Chancelleries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostUserСode1С> PostUserСode1С { get; set; }
    }
}
