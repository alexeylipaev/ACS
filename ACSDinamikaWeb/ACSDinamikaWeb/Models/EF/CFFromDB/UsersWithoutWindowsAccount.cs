namespace ACSDinamikaWeb.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersWithoutWindowsAccount")]
    public partial class UsersWithoutWindowsAccount
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

        public Guid? Guid1C { get; set; }
    }
}
