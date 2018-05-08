using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
   public class ProjectRegistry
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Шифр
        /// </summary>
        public string Cipher { get; set; }

        /// <summary>
        /// Номер договора
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Индекс изделия по ТЗ
        /// </summary>
        public string IndexOfArticlesOnTK { get; set; }

        /// <summary>
        /// Сокращенные наименование изделия из состава УТК по ТЗ
        /// </summary>
        public string AbbreviationsProductsStructureUTKTK { get; set; }

        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime? PlanStartDate { get; set; }

        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime? PlanEndDate { get; set; }

        /// <summary>
        /// Фактическая дата начала
        /// </summary>
        public DateTime? ActualStartDate { get; set; }

        /// <summary>
        /// Фактическая дата окончания
        /// </summary>
        public DateTime? ActualEndDate { get; set; }

        /// <summary>
        /// Дата предоставления план графика работ
        /// </summary>
        public DateTime? DateOfSubmissionWorkSchedulePlan { get; set; }

        /// <summary>
        /// Удален
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}
