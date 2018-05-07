using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    public class InputControlPKIDTO: SystemParametersDTO
    {
        public InputControlPKIDTO()
        {
            ReceivedDoc = new HashSet<ReceivedDocPKIDTO>();
        }
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        public Guid? Code1C { get; set; }

        /// <summary>
        /// Дата поступления
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Номер проекта
        /// </summary>
        public string NumberProject { get; set; }

        /// <summary>
        /// Шифр проекта
        /// </summary>
        public string CipherProject { get; set; }

        /// <summary>
        /// Номенклатура
        /// </summary>
        public string Nomenclature { get; set; }

        /// <summary>
        /// Контрагент
        /// </summary>
        public string Contractor { get; set; }


        /// <summary>
        /// Заводской номер
        /// </summary>
        public string SerialNumber { get; set; }


        /// <summary>
        /// Номер партии
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Дата изготовления
        /// </summary>
        public DateTime? DateOfManufacture { get; set; }

        /// <summary>
        /// Гарантийный срок хранения
        /// </summary>
        public string ShelfLife { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string PassportNumber { get; set; }

        /// <summary>
        /// Документ На Поставку
        /// </summary>
        public string DocumentForTheSupply{ get; set; }
        

        /// <summary>
        /// Место хранения
        /// </summary>
        public string StorageLocation { get; set; }

        /// <summary>
        /// Количество брака
        /// </summary>
        public int AmountDefect { get; set; }

        /// <summary>
        /// Проверено ОТК
        /// </summary>
        public bool CheckOTK { get; set; }

        /// <summary>
        /// Дата проверки
        /// </summary>
        public DateTime? DateOfReview { get; set; }

        /// <summary>
        /// Кому передано
        /// </summary>
        public virtual EmployeeDTO GotEmpl { get; set; }

        /// <summary>
        /// Кто проверил
        /// </summary>
        public virtual EmployeeDTO CheckedByWhom { get; set; }

        /// <summary>
        /// Отправленно
        /// </summary>
        public  bool IsSent { get; set; }

        /// <summary>
        /// Поступившая документация
        /// </summary>
        ICollection<ReceivedDocPKIDTO> ReceivedDoc { get; set; }

    
    }
}
