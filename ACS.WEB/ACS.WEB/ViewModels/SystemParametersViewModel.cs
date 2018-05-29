using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ACS.WEB.ViewModels
{
    public class SystemParametersViewModel
    {
        [Display(Name = "Guid")]
        public Guid s_Guid { get; private set; }
        [Display(Name = "ID Автора")]
        public int s_AuthorId { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime s_DateCreation { get; private set; }
        [Display(Name = "ID автора последнего редактирования")]
        public int s_EditorId { get; set; }
        [Display(Name = "Дата последнего редактирования")]
        public DateTime s_EditDate { get; set; }

        [Display(Name = "Заблокирован")]
        public bool? s_IsLocked { get; set; } = false;
        [Display(Name = "ID кем заблокирован")]
        public int? s_LockedBy_Id { get; set; }

        [Display(Name = "В корзине")]
        public bool s_InBasket { get; set; } = false;

    }
}