using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACSWeb.ViewModel
{
    public partial class ASPIdentityUserViewModel : SystemParametersViewModel
    {
        public ASPIdentityUserViewModel()
        {
            Claims = new HashSet<ASPClaimsIdentityUserViewModel>();
            Logins = new HashSet<ASPLoginsIdentityUserViewModel>();
            Roles = new HashSet<ASPRolesIdentityUserViewModel>();
        }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Начальная и хэшированная формы пароля пользователя
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Случайное значение, которое должно меняться при изменении учетных данных пользователя 
        /// (смена пароля, удаление имени входа)
        /// </summary>
        public string SecurityStamp { get; set; }

        public string EMail { get; set; }

        /// <summary>
        /// Свойство навигации для утверждений пользователя
        /// </summary>
        public virtual ICollection<ASPClaimsIdentityUserViewModel> Claims { get; set; }

        /// <summary>
        /// Логины (1 пользователь имеет N логинов (google, fb...))
        /// </summary>
        public virtual ICollection<ASPLoginsIdentityUserViewModel> Logins { get; set; }

        /// <summary>
        /// Роли N to N
        /// </summary>
        public virtual ICollection<ASPRolesIdentityUserViewModel> Roles { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public virtual UserViewModel User { get; set; }

    }
}