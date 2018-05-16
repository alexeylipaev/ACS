using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    public partial class ChancelleryDTO : SystemParametersDTO
    {

        public ChancelleryDTO()
        {
            FileRecordChancelleries = new HashSet<FileRecordChancelleryDTO>();
            FromChancelleries = new HashSet<FromChancelleryDTO>();
            ToChancelleries = new HashSet<ToChancelleryDTO>();
        }

        public int id { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime? DateRegistration { get; set; }

        /// <summary>
        /// Регистрационный номер
        /// </summary>
        public string RegistrationNumber { get; set; }


        /// <summary>
        /// Описание
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Notice { get; set; }

        #region папка

        //public int? FolderId { get; set; }

        /// <summary>
        /// Папка
        /// </summary>
        public virtual FolderChancelleryDTO FolderChancellery { get; set; }

        #endregion

        #region Журнал

        //public int? JournalRegistrationsId { get; set; }
        /// <summary>
        /// Журнал
        /// </summary>
        public virtual JournalRegistrationsChancelleryDTO JournalRegistrationsChancellery { get; set; }

        #endregion

        #region Тип

        
        //public byte? TypeRecordId { get; set; }

        /// <summary>
        /// Тип записи
        /// </summary>
        public virtual TypeRecordChancelleryDTO TypeRecordChancellery { get; set; }

        #endregion

        #region Ответственный

        //public int? ResponsibleEmployee_Id { get; set; }

        /// <summary>
        /// Ответственные
        /// </summary>
        public virtual IEnumerable<EmployeeDTO> ResponsibleEmployees { get; set; }

        #endregion


        /// <summary>
        /// Файлы
        /// </summary>
        public virtual ICollection<FileRecordChancelleryDTO> FileRecordChancelleries { get; set; }


        /// <summary>
        /// От кого"
        /// </summary>
        public virtual ICollection<FromChancelleryDTO> FromChancelleries { get; set; }


        /// <summary>
        /// Кому
        /// </summary>
        public virtual ICollection<ToChancelleryDTO> ToChancelleries { get; set; }
    }
}
