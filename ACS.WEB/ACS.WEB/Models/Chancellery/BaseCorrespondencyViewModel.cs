using ACS.WEB.ViewModel;
using System;
using System.Collections.Generic;

namespace ACS.WEB.ViewModels
{
    public class BaseCorrespondencyViewModel : SystemParametersViewModel
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

        //public int? FolderId { get; set; }

        /// <summary>
        /// Папка
        /// </summary>
        public virtual FolderChancelleryViewModel FolderChancellery { get; set; }

        #endregion

        #region Журнал

        //public int? JournalRegistrationsId { get; set; }
        /// <summary>
        /// Журнал
        /// </summary>
        public virtual JournalRegistrationsChancelleryViewModel JournalRegistrationsChancellery { get; set; }

        #endregion

        #region Тип


        //public byte? TypeRecordId { get; set; }

        /// <summary>
        /// Тип записи
        /// </summary>
        public virtual TypeRecordChancelleryViewModel TypeRecordChancellery { get; set; }

        #endregion

        #region Ответственный

        //public int? ResponsibleEmployee_Id { get; set; }

        /// <summary>
        /// Ответственный
        /// </summary>
        public IEnumerable<EmployeeViewModel> ResponsibleEmployees { get; set; }

        #endregion

        /// <summary>
        /// Файлы
        /// </summary>
        public virtual ICollection<FileRecordChancelleryViewModel> FileRecordChancelleries { get; set; }

    }
}
