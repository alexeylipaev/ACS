using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModel
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public partial class EmployeeViewModel : SystemParametersViewModel
    {

        public EmployeeViewModel()
        {
            Accesses = new HashSet<AccessViewModel>();
            Chancelleries = new HashSet<ChancelleryViewModel>();
            PostsEmployeesСode1С = new HashSet<PostsEmployeeСode1СViewModel>();
        }
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Имя")]
        public string FName { get; set; }
        [Display(Name = "Фамилия")]
        public string LName { get; set; }
        [Display(Name = "Отчество")]
        public string MName { get; set; }

        public string Email { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        [Display(Name = "ФИО")]
        public string FullName
        {
            get
            {
                return (this.LName ?? "") + " " + (this.FName ?? "") + " " + (this.MName ?? "");
            }
        }

        public string SID { get; set; }

        public Guid? Guid1C { get; set; }

        public virtual ApplicationUserViewModel ApplicationUser { get; set; }

        /// <summary>
        /// Доступы пользователя
        /// </summary>
        public virtual ICollection<AccessViewModel> Accesses { get; set; }

        /// <summary>
        /// Канцелярские записи пользователя
        /// </summary>
        public virtual ICollection<ChancelleryViewModel> Chancelleries { get; set; }

        /// <summary>
        /// Коды1С должностей пользователя
        /// </summary>
        public virtual ICollection<PostsEmployeeСode1СViewModel> PostsEmployeesСode1С { get; set; }
    }
}