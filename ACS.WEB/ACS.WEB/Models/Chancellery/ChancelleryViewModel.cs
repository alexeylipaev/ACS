using ACS.WEB.Models;
using ACS.WEB.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ACS.WEB.ViewModel
{
    //public enum TypesChancellery : byte
    //{
    //    [Display(Name = "Входящая")]
    //    Входящая = 1,
    //    [Display(Name = "Исходящая")]
    //    Исходящая,
    //    [Display(Name = "Внутреняя")]
    //    Внутреняя
    //}

    public partial class ChancelleryViewModel : SystemParametersViewModel
    {
        public ChancelleryViewModel()
        {
            FileRecordChancelleries = new HashSet<FileRecordChancelleryViewModel>();
            FromChancelleries = new HashSet<FromChancelleryViewModel>();
            ToChancelleries = new HashSet<ToChancelleryViewModel>();
        }

        [Display(Name = "ID")]
        public int id { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата регистрации")]
        [Required]
        public DateTime DateRegistration { get; set; }

        /// <summary>
        /// Регистрационный номер
        /// </summary>
        [Display(Name = "Регистрационный номер")]
        [Required]
        public string RegistrationNumber { get; set; }


        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Summary { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        [Display(Name = "Примечание")]
        [DataType(DataType.MultilineText)]
        public string Notice { get; set; }

        #region папка

        public int? FolderChancelleryId { get; set; }

        /// <summary>
        /// Папка
        /// </summary>
        [Display(Name = "Папка")]
        public FolderChancelleryViewModel FolderChancellery { get; set; }
        public SelectedFolderChancellery SelectedFolder { get; set; }
        #endregion

        #region Журнал

        [Display(Name = "Журнал регистрации")]
        //public int? JournalRegistrationsId { get; set; }
        /// <summary>
        /// Журнал
        /// </summary>
        public JournalRegistrationsChancelleryViewModel JournalRegistrationsChancellery { get; set; }
        [Display(Name = "Журнал регистрации")]
        public int JournalRegistrationsChancelleryId { get; set; }
        public SelectedJournalRegChancellery SelectedJournalsReg { get; set; }
        #endregion

        #region Тип

        [Display(Name = "Тип")]
        public int? TypeRecordChancelleryId { get; set; }

        private TypeRecordChancelleryViewModel _typeRecordChancellery;

        /// <summary>
        /// Тип записи
        /// </summary>
        [Display(Name = "Тип записи")]
        public TypeRecordChancelleryViewModel TypeRecordChancellery
        {
            get { return _typeRecordChancellery; }
            set
            {

                _typeRecordChancellery = value;

                //switch (_typeRecordChancellery.id)
                //{
                //    case 1:
                //        {
                //            TypeChancellery = TypesChancellery.Входящая;
                //            break;
                //        }
                //    case 2:
                //        {
                //            TypeChancellery = TypesChancellery.Исходящая;
                //            break;
                //        }
                //    case 3:
                //        {
                //            TypeChancellery = TypesChancellery.Внутреняя;
                //            break;
                //        }
                //    default:
                //        break;
                //}


            }
        }
        //public TypesChancellery TypeChancellery { get; set; }

        #endregion

        #region Ответственный

        public int? EmployeeId { get; set; }

        /// <summary>
        /// Ответственный
        /// </summary>
        [Display(Name = "Ответственный")]
        public virtual EmployeeViewModel Employee { get; set; }

        #endregion


        /// <summary>
        /// Файлы
        /// </summary>
        //[DataType(DataType.Upload)]
        [Display(Name = "Файлы")]
        public ICollection<FileRecordChancelleryViewModel> FileRecordChancelleries { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        /// <summary>
        /// От кого"
        /// </summary>
        [Display(Name = "От кого")]
        public ICollection<FromChancelleryViewModel> FromChancelleries { get; set; }


        /// <summary>
        /// Кому
        /// </summary>
        [Display(Name = "Кому")]
        public ICollection<ToChancelleryViewModel> ToChancelleries { get; set; }


        public SelectedEmployeeViewModel SelectedResponsible { get; set; }
        public SelectedExternalOrgViewModel Selected_ExtOrg { get; set; }
        public SelectedEmployeeViewModel Selected_From_Empl { get; set; }
        public SelectedEmployeeViewModel Selected_To_Empl { get; set; }
    }
}




