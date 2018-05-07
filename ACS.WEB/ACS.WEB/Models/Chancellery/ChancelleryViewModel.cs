using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModel
{
    public partial class ChancelleryViewModel : SystemParametersViewModel
    {
        public ChancelleryViewModel()
        {
            FileRecordChancelleries = new HashSet<FileRecordChancelleryViewModel>();
            FromChancelleries = new HashSet<FromChancelleryViewModel>();
            ToChancelleries = new HashSet<ToChancelleryViewModel>();
        }

        public int id { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата регистрации")]
        public DateTime? DateRegistration { get; set; }

        /// <summary>
        /// Регистрационный номер
        /// </summary>
        [Display(Name = "Регистрационный номер")]
        public string RegistrationNumber { get; set; }


        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }

        #region папка

        //public int? FolderId { get; set; }

        /// <summary>
        /// Папка
        /// </summary>
        public FolderChancelleryViewModel FolderChancellery { get; set; }

        #endregion

        #region Журнал

        //public int? JournalRegistrationsId { get; set; }
        /// <summary>
        /// Журнал
        /// </summary>
        public JournalRegistrationsChancelleryViewModel JournalRegistrationsChancellery { get; set; }

        #endregion

        #region Тип


        //public byte? TypeRecordId { get; set; }

        /// <summary>
        /// Тип записи
        /// </summary>
        public TypeRecordChancelleryViewModel TypeRecordChancellery { get; set; }

        #endregion

        #region Ответственный
        [Display(Name = "Ответственный")]
        public int? ResponsibleEmployee_Id { get; set; }

        /// <summary>
        /// Ответственный
        /// </summary>
        //public virtual EmployeeViewModel Employee { get; set; }

        #endregion


        /// <summary>
        /// Файлы
        /// </summary>
        [DataType(DataType.Upload)]
        public ICollection<FileRecordChancelleryViewModel> FileRecordChancelleries { get; set; }


        /// <summary>
        /// От кого"
        /// </summary>
        public ICollection<FromChancelleryViewModel> FromChancelleries { get; set; }


        /// <summary>
        /// Кому
        /// </summary>
        public ICollection<ToChancelleryViewModel> ToChancelleries { get; set; }
    }
}
