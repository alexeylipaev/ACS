using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.DAL.Entities
{
    public class SystemParameters
    {

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DefaultValue("newsequentialid()")]
        public Guid s_Guid { get; private set; } = Guid.NewGuid();

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DefaultValue(1)]
        public int s_AuthorId { get; set; } = 1;

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DefaultValue("getdate()")]
        public DateTime s_DateCreation { get; private set; } = DateTime.Now;

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DefaultValue(1)]
        public int s_EditorId { get; set; } = 1;

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DefaultValue("getdate()")]
        public DateTime s_EditDate { get; set; } = DateTime.Now;

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DefaultValue(0)]
        public bool? s_IsLocked { get; set; } = false;

        public int? s_LockedBy_Id { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DefaultValue(0)]
        public bool s_InBasket { get; set; } = false;
    }
}