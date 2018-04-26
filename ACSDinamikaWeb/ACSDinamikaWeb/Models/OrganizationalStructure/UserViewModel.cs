using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACSWeb.ViewModel
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public partial class UserViewModel : SystemParametersViewModel
    {

        //public UserViewModel()
        //{
        //    Accesses = new HashSet<AccessViewModel>();
        //    Chancelleries = new HashSet<ChancelleryViewModel>();
        //    PostUserСode1С = new HashSet<PostUserСode1СViewModel>();
        //}

        public int Id { get; set; }

       
        public string FName { get; set; }

        public string LName { get; set; }

        public string MName { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// Табельный номер
        /// </summary>
        public string PersonnelNumber { get; set; }

       [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

    
        public string SID { get; set; }

        public Guid? Guid1C { get; set; }

        ///// <summary>
        ///// Доступы пользователя
        ///// </summary>
        //public virtual ICollection<AccessViewModel> Accesses { get; set; }

        ///// <summary>
        ///// Канцелярские записи пользователя
        ///// </summary>
        //public virtual ICollection<ChancelleryViewModel> Chancelleries { get; set; }

        ///// <summary>
        ///// Коды1С должностей пользователя
        ///// </summary>
        //public virtual ICollection<PostUserСode1СViewModel> PostUserСode1С { get; set; }
    }
}