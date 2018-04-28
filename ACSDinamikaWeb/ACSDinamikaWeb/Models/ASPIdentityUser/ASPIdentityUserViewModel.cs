using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACSWeb.ViewModel
{
    public partial class ApplicationUserViewModel : SystemParametersViewModel
    {
        //public ApplicationUserViewModel()
        //{
        //    Claims = new HashSet<ApplicationClaimViewModel>();
        //    Logins = new HashSet<ApplicationLoginViewModel>();
        //    Roles = new HashSet<ApplicationRoleViewModel>();
        //}

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        public string SID { get; set; }

        /// <summary>
        /// Начальная и хэшированная формы пароля пользователя
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Случайное значение, которое должно меняться при изменении учетных данных пользователя 
        /// (смена пароля, удаление имени входа)
        /// </summary>
        public string SecurityStamp { get; set; }

        public string Email { get; set; }

        ///// <summary>
        ///// Свойство навигации для утверждений пользователя
        ///// </summary>
        //public virtual ICollection<ApplicationClaimViewModel> Claims { get; set; }

        ///// <summary>
        ///// Логины (1 пользователь имеет N логинов (google, fb...))
        ///// </summary>
        //public virtual ICollection<ApplicationLoginViewModel> Logins { get; set; }

        ///// <summary>
        ///// Роли N to N
        ///// </summary>
        //public virtual ICollection<ApplicationRoleViewModel> Roles { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        //public virtual UserViewModel Employee { get; set; }

    }
}