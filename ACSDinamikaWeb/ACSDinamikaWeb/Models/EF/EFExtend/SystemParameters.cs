using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACSDinamikaWeb.Models.EF
{
    public class SystemParameters
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("newsequentialid()")]
        public Guid s_Guid { get; set; }

        public int? s_AuthorID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime s_DateCreation { get; set; }

        public int? s_EditorID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime s_EditDate { get; set; }

        public bool? s_IsLocked { get; set; }

        public int? s_LockedBy_Id { get; set; }

        public bool? s_InBasket { get; set; }
    }
}