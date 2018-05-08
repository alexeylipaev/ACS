using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public partial class SystemParameters:IEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("newsequentialid()")]
        public Guid s_Guid { get; private set; }

        public int? s_AuthorID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime s_DateCreation { get; private set; }

        public int? s_EditorID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime s_EditDate { get; private set; }

        public bool? s_IsLocked { get; set; }

        public int? s_LockedBy_Id { get; set; }

        public bool? s_InBasket { get; set; }
    }
}
