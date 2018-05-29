using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    public partial class SystemParameters 
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DefaultValue("newsequentialid()")]
        public Guid s_Guid { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(1)]
        public int s_AuthorId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime s_DateCreation { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(1)]
        public int s_EditorId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime s_EditDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(0)]
        public bool? s_IsLocked { get; set; }

        public int? s_LockedBy_Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(0)]
        public bool s_InBasket { get; set; }
    }
}
