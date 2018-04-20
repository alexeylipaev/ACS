namespace ACSDinamikaWeb.Models.EF.CFFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FileRecordChancellery")]
    public partial class FileRecordChancellery : SystemParameters
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(10)]
        public string format { get; set; }

        [Required]
        [StringLength(1)]
        public string Path { get; set; }

        public int? RecordChancelleryId { get; set; }

        public virtual Chancellery Chancellery { get; set; }
    }
}
