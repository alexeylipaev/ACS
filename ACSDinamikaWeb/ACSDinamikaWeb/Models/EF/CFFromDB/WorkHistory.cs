namespace ACSWeb.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkHistory")]
    public partial class WorkHistory : SystemParameters
    {
        public int Id { get; set; }

        public int PostUserСode1СId { get; set; }

        [StringLength(100)]
        public string PostName { get; set; }


        public int DepartmentId { get; set; }

        public double? Rate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public virtual Department Department { get; set; }

        //public virtual PostUser PostUser { get; set; }

        public virtual PostUserСode1С PostUserСode1С { get; set; }
    }
}
