using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
   public class ProjectRegistryViewModel : SystemParametersViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary> 
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        [Display(Name = "Код")]
        public Guid Code { get; set; }

        [Display(Name = "Номер проекта")]
        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }

        [Display(Name = "Шифр проекта")]
        /// <summary>
        /// Шифр
        /// </summary>
        public string Cipher { get; set; }

        [Display(Name = "Номер договора")]
        /// <summary>
        /// Номер договора
        /// </summary>
        public string ContractNumber { get; set; }

        [Display(Name = "Описание")]
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        [Display(Name = "Статус")]
        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }

        [Display(Name = "Индекс изделия по ТЗ")]
        /// <summary>
        /// Индекс изделия по ТЗ
        /// </summary>
        public string IndexOfArticlesOnTK { get; set; }

        [Display(Name = "Сокращенные наименование изделия из состава УТК по ТЗ")]
        /// <summary>
        /// Сокращенные наименование изделия из состава УТК по ТЗ
        /// </summary>
        public string AbbreviationsProductsStructureUTKTK { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата начала")]
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime? PlanStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата окончания")]
        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime? PlanEndDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Фактическая дата начала")]
        /// <summary>
        /// Фактическая дата начала
        /// </summary>
        public DateTime? ActualStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = " Фактическая дата окончания")]
        /// <summary>
        /// Фактическая дата окончания
        /// </summary>
        public DateTime? ActualEndDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата предоставления план графика работ")]
        /// <summary>
        /// Дата предоставления план графика работ
        /// </summary>
        public DateTime? DateOfSubmissionWorkSchedulePlan { get; set; }

    
        [Display(Name = "Удален")]
        /// <summary>
        /// Удален
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}
