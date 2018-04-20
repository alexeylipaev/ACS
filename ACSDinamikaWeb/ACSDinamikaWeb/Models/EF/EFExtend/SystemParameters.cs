using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACSWeb.Models.EF
{
    public class SystemParameters
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("newsequentialid()")]
        [Display(Name = "Guid")]
        public Guid s_Guid { get; private set; }

        [Display(Name = "Автор")]
        public int? s_AuthorID { get;  set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        [Display(Name = "Дата создания")]
        public DateTime s_DateCreation { get; private set; }
        [Display(Name = "Редактировано кем")]
        public int? s_EditorID { get;  set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        [Display(Name = "Последняя дата редактирования")]
        public DateTime s_EditDate { get; private set; }

        [Display(Name = "Заблокировано")]
        public bool? s_IsLocked { get; set; }
        [Display(Name = "Заблокировано кем")]
        public int? s_LockedBy_Id { get; set; }
        [Display(Name = "Удалено")]
        public bool? s_InBasket { get; set; }
    }
}