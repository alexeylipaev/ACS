namespace ACSDinamikaWeb.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PassportDataUser")]
    public partial class PassportDataUser
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [StringLength(30)]
        public string LName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string FName { get; set; }

        [StringLength(25)]
        public string MName { get; set; }

        [StringLength(6)]
        public string PassportSeries { get; set; }

        [StringLength(8)]
        public string PassportNumber { get; set; }

        [StringLength(25)]
        public string PassportIssuedBy { get; set; }

        [StringLength(6)]
        public string PassportUnitCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PassportDateOfIssue { get; set; }

        public Guid? Guid1C { get; set; }
    }
}
