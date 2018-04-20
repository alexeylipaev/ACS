namespace ACSWeb.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASPClaimsIdentityUser")]
    public partial class ASPClaimsIdentityUser : SystemParameters
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ClaimsId { get; set; }

        [Required]
        [StringLength(50)]
        public string IdentityUserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

    }
}
