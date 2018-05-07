using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModel
{
    public partial class ApplicationUserViewModel 
    {
        public ApplicationUserViewModel()
        {
            Claims = new HashSet<AppUserClaimViewModel>();
            Logins = new HashSet<AppUserLoginViewModel>();
            Roles = new HashSet<AppUserRoleViewModel>();
            DataRoles = new HashSet<ApplicationRoleViewModel>();
        }

        public int id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Случайное значение, которое должно меняться при изменении учетных данных пользователя 
        /// (смена пароля, удаление имени входа)
        /// </summary>
        public string SecurityStamp { get; set; }


        public string SID { get; set; }

        /// <summary>
        /// id пользователя
        /// </summary>
        public virtual int? Employee_Id { get; set; }

        /// <summary>
        /// Свойство навигации для утверждений пользователя
        /// </summary>
        public virtual ICollection<AppUserClaimViewModel> Claims { get; set; }

        /// <summary>
        /// Логины (1 пользователь имеет N логинов (google, fb...))
        /// </summary>
        public virtual ICollection<AppUserLoginViewModel> Logins { get; set; }

        /// <summary>
        /// ID Ролей и ID Изера
        /// </summary>
        public virtual ICollection<AppUserRoleViewModel> Roles { get; set; }

        public virtual ICollection<ApplicationRoleViewModel> DataRoles { get; set; }

    }
}