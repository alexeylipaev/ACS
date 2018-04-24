namespace ACSWeb.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExternalOrganizationChancellery")]
    public partial class ExternalOrganizationChancellery : SystemParameters
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Address { get; set; }


        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Email { get; set; }

        [StringLength(14)]
        public string Phone { get; set; }

    }
}
