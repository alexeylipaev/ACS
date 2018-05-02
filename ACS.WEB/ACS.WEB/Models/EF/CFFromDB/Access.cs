namespace ACS.WEB.Models.EF.CFFromDB
{
 
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Access")]
    public partial class Access: SystemParameters
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public Guid? GuidObject { get; set; }

        public int? TypeAccessId { get; set; }

        public int? Value { get; set; }

        [StringLength(100)]
        public string Note { get; set; }


        public virtual TypeAccess TypeAccess { get; set; }

        public virtual User User { get; set; }
    }
}
