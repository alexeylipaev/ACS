namespace ACSWeb.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASPLoginsIdentityUser")]
    public partial class ASPLoginsIdentityUser : SystemParameters
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string IdentityUserId { get; set; }

        public string ProviderKey { get; set; }

        public string LoginProvider { get; set; }

    }
}
