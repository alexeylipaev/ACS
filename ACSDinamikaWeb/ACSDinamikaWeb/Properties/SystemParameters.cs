using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACSWeb.Models
{
    [ComplexType]
    public partial class SystemParameters
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

        /// <summary>
        /// Заблокирован?
        /// </summary>
        public bool? s_IsLocked { get; set; }

        /// <summary>
        /// кем заблокирован
        /// </summary>
        public int? s_LockedBy_Id { get; set; }

        /// <summary>
        /// В корзине?
        /// </summary>
        public bool? s_InBasket { get; set; }
    }
}