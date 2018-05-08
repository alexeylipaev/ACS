
using System;
using System.ComponentModel.DataAnnotations;

namespace ACS.WEB.ViewModel
{
    public class ReceivedDocPKIViewModel : SystemParametersViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ПО
        /// </summary>
        [Display(Name = "ПО")]
        public bool IsSoftware { get; set; }

        /// <summary>
        /// наименование документа
        /// </summary>
        [Display(Name = "Наименование документа")]
        public string Name { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        [Display(Name = "Номер паспорта")]
        public string PassportNumber { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        [Display(Name = "Количество")]
        public int Amount { get; set; }

        /// <summary>
        /// Место хранения
        /// </summary>
        [Display(Name = "Место хранения")]
        public string StorageLocation { get; set; }

        /// <summary>
        /// Количество дефекта
        /// </summary>
        [Display(Name = "Количество дефекта")]
        public int AmountDefect { get; set; }


       

        /// <summary>
        /// Дата проверки
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата проверки")]
        public DateTime? DateOfReview { get; set; }



        /// <summary>
        /// Кому передано
        /// </summary>
        [Display(Name = "Кому передано")]
        public virtual EmployeeViewModel GotEmpl { get; set; }

        /// <summary>
        /// Проверено ОТК
        /// </summary>
        [Display(Name = "Проверено ОТК")]
        public bool CheckOTK { get; set; }

        /// <summary>
        /// Кто проверил
        /// </summary>
        [Display(Name = "Кому передано")]
        public virtual EmployeeViewModel CheckedByWhom { get; set; }


        /// <summary>
        /// Отправлено
        /// </summary>
        [Display(Name = "Отправлено")]
        public bool IsSent { get; set; }

        /// <summary>
        /// Покупное изделие
        /// </summary>
        [Display(Name = "Покупное изделие")]
        public virtual InputControlPKIViewModel PKI { get; set; }

    }
}