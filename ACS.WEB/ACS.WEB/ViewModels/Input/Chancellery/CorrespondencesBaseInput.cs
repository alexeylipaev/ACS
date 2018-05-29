using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{
    public class CorrespondencesBaseInput : EntityViewModel
    {
        #region simple prop
        /// <summary>
        /// Регистрационный номер
        /// </summary>
        [Display(Name = "Регистрационный номер")]
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        [Display(Name = "Дата регистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateRegistration { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        public string Summary { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        [Display(Name = "Примечание")]
        public string Notice { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        [Display(Name = "Статус")]
        public string Status { get; set; }

        #endregion
        /// <summary>
        /// Папка
        /// </summary>
        [Display(Name = "Тип")]
        public int TypeRecordChancelleryId { get; set; }
        /// <summary>
        /// Папка
        /// </summary>
        [Display(Name = "Папка")]
        public int? FolderChancelleryId { get; set; }
        /// <summary>
        /// Журнал регистрации
        /// </summary>
        [Display(Name = "Журнал регистрации")]
        public int? JournalRegistrationsChancelleryId { get; set; }
        /// <summary>
        /// Ответственный
        /// </summary>
        [Display(Name = "Ответственные")]
        public  IEnumerable<int> ResponsibleEmployees { get; set; }
        /// <summary>
        /// Файлы
        /// </summary>
        [Display(Name = "Файлы")]
        public  IEnumerable<int> FileRecordChancelleries { get; set; }
    }
}