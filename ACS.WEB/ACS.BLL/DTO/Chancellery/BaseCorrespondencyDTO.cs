using ACS.BLL.DTO;
using System;
using System.Collections.Generic;

namespace ACS.BLL.DTO
{
    public class BaseCorrespondencyDTO : SystemParametersDTO
    {
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

        public int? FolderId { get; set; }

        /// <summary>
        /// Папка
        /// </summary>
        //public virtual FolderChancelleryDTO FolderChancellery { get; set; }

        #endregion

        #region Журнал

        public int? JournalRegistrationsId { get; set; }

        /// <summary>
        /// Журнал
        /// </summary>
        //public virtual JournalRegistrationsChancelleryDTO JournalRegistrationsChancellery { get; set; }

        #endregion

        #region Тип


        public int TypeRecordId { get; set; }

        /// <summary>
        /// Тип записи
        /// </summary>
        //public virtual TypeRecordChancelleryDTO TypeRecordChancellery { get; set; }

        #endregion

        #region Ответственный

        //public int? ResponsibleEmployee_Id { get; set; }

        /// <summary>
        /// Ответственные
        /// </summary>
        public IEnumerable<int> ResponsibleEmployees { get; set; }

        #endregion

        /// <summary>
        /// Файлы
        /// </summary>
        public virtual ICollection<int> FileRecordChancelleries { get; set; }

    }
}
