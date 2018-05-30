using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using Omu.AwesomeMvc;
using ACS.WEB.ViewModel;

namespace ACS.WEB.ViewModels.Input
{

    public partial class ChancelleryInput : SystemParametersViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Регистрационный номер
        /// </summary>
        [Display(Name = "Регистрационный номер")]
        [Required]
        public string RegistrationNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата регистрации")]
        [Required]
        public DateTime? DateRegistration { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Summary { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        [Display(Name = "Примечание")]
        [DataType(DataType.MultilineText)]
        public string Notice { get; set; }



        /// <summary>
        /// Журнал
        /// </summary>
        [UIHint("Lookup")]
        [Required]
        public int? Journal { get; set; }

        /// <summary>
        /// Папка
        /// </summary>
        [UIHint("Lookup")]
        [Required]
        public int? Folder { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        [UIHint("Lookup")]
        [Required]
        public int? Type { get; set; }

        /// <summary>
        /// Ответственные
        /// </summary>
        [Required]
        [UIHint("MultiLookup")]
        public IEnumerable<int> Responsible { get; set; }

        ///// <summary>
        ///// Файлы
        ///// </summary>
        //[Required]
        //[UIHint("MultiLookup")]
        //public IEnumerable<int> Files { get; set; }

        ///// <summary>
        ///// От кого
        ///// </summary>
        //[Required]
        //[UIHint("MultiLookup")]
        //public IEnumerable<int> From { get; set; }

        ///// <summary>
        ///// Кому
        ///// </summary>
        //[Required]
        //[UIHint("MultiLookup")]
        //public IEnumerable<int> To { get; set; }
        //[Required]
        //[UIHint("Odropdown")]
        //[AweUrl(Action = "GetAllResponsible", Controller = "Data")]
        //[DisplayName("Bonus meal")]
        //public int? BonusMealId { get; set; }

    }
}