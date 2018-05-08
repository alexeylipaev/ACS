using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    public class InputControlPKIViewModel : SystemParametersViewModel
    {
        public InputControlPKIViewModel()
        {
            ReceivedDoc = new HashSet<ReceivedDocPKIViewModel>();
        }
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

    
        [Display(Name = "Код")]
        public Guid? Code1C { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата поступления")]
        public DateTime? Date { get; set; }

        [Display(Name = "Номер проекта")]
        public string NumberProject { get; set; }

        [Display(Name = "Шифр проекта")]
        public string CipherProject { get; set; }


        [Display(Name = "Изделие")]
        public string Nomenclature { get; set; }

        [Display(Name = "Контрагент")]
        public string Contractor { get; set; }


        /// <summary>
        /// Заводской номер
        /// </summary>
        [Display(Name = "Заводской номер")]
        public string SerialNumber { get; set; }


        /// <summary>
        /// Номер партии
        /// </summary>
          [Display(Name = "Номер партии")]
        public string BatchNumber { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        [Display(Name = "Количество")]
        public int Amount { get; set; }

        /// <summary>
        /// Дата изготовления
        /// </summary>

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата изготовления")]
        public DateTime? DateOfManufacture { get; set; }

        /// <summary>
        /// Гарантийный срок хранения
        /// </summary>
        [Display(Name = "Гарантийный срок хранения")]
        public string ShelfLife { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        [Display(Name = "Номер паспорта")]
        public string PassportNumber { get; set; }

        /// <summary>
        /// Документ На Поставку
        /// </summary>
        [Display(Name = "Документ На поставку")]
        public string DocumentForTheSupply{ get; set; }


        /// <summary>
        /// Место хранения
        /// </summary>
        [Display(Name = "Место хранения")]
        public string StorageLocation { get; set; }

        /// <summary>
        /// Количество брака
        /// </summary>
        [Display(Name = "Количество брака")]
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
        [Display(Name = "Кто проверил")]
        public virtual EmployeeViewModel CheckedByWhom { get; set; }

        /// <summary>
        /// Отправленно
        /// </summary>
        [Display(Name = "Отправленно")]
        public  bool IsSent { get; set; }

        /// <summary>
        /// Поступившая документация
        /// </summary>
        [Display(Name = "Поступившая документация")]
        ICollection<ReceivedDocPKIViewModel> ReceivedDoc { get; set; }

    
    }
}
