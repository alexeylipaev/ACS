namespace ACS.WEB.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASPRolesIdentityUser")]
    public partial class ASPRolesIdentityUser : SystemParameters
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string IdentityUserId { get; set; }

    }
}
