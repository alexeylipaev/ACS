using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.ViewModel
{
    public partial class ChancelleryViewModel : SystemParametersViewModel
    {

        public ChancelleryViewModel()
        {
            FileRecordChancelleries = new HashSet<FileRecordChancelleryViewModel>();
            FromChancelleries = new HashSet<FromChancelleryViewModel>();
            ToChancelleries = new HashSet<ToChancelleryViewModel>();
        }

        public int Id { get; set; }

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

        #region папка

        public int? FolderId { get; set; }
        /// <summary>
        /// Папка
        /// </summary>
        public virtual FolderChancelleryViewModel FolderChancellery { get; set; }

        #endregion

        #region Журнал

        public int? JournalRegistrationsId { get; set; }
        /// <summary>
        /// Журнал
        /// </summary>
        public virtual JournalRegistrationsChancelleryViewModel JournalRegistrationsChancellery { get; set; }

        #endregion

        #region Тип

        
        public byte? TypeRecordId { get; set; }

        /// <summary>
        /// Тип записи
        /// </summary>
        public virtual TypeRecordChancelleryViewModel TypeRecordChancellery { get; set; }

        #endregion

        #region Ответственный

        public int? ResponsibleUserId { get; set; }

        /// <summary>
        /// Ответственный
        /// </summary>
        public virtual UserViewModel User { get; set; }

        #endregion


        /// <summary>
        /// Файлы
        /// </summary>
        public virtual ICollection<FileRecordChancelleryViewModel> FileRecordChancelleries { get; set; }


        /// <summary>
        /// От кого"
        /// </summary>
        public virtual ICollection<FromChancelleryViewModel> FromChancelleries { get; set; }


        /// <summary>
        /// Кому
        /// </summary>
        public virtual ICollection<ToChancelleryViewModel> ToChancelleries { get; set; }
    }
}
