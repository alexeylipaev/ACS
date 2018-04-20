namespace ACSWeb.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ToChancellery")]
    public partial class ToChancellery : SystemParameters
    {
        public int Id { get; set; }

        public Guid? ToGuid { get; set; }

        public int? TableId { get; set; }

        public int? RecordChancelleryId { get; set; }

        public virtual Chancellery Chancellery { get; set; }
    }
}
