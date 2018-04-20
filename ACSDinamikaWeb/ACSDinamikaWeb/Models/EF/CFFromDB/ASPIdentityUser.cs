namespace ACSWeb.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASPIdentityUser")]
    public partial class ASPIdentityUser : SystemParameters
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string IdentityUserId { get; set; }

        [Required]
        [StringLength(30)]
        public string IdentityUserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string SecurityStamp { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
