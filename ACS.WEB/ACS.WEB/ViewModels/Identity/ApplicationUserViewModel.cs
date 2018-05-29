using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACS.WEB.ViewModels
{
    public partial class ApplicationUserViewModel 
    {

        [Display(Name = "ID")]
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


        public int? EmployeeId { get; set; }
        /// <summary>
        /// Свойство навигации для утверждений пользователя
        /// </summary>
        public  IEnumerable<int> Claims { get; set; }

        /// <summary>
        /// Логины (1 пользователь имеет N логинов (google, fb...))
        /// </summary>
        public IEnumerable<AppUserLoginViewModel> Logins { get; set; }

        /// <summary>
        /// ID Ролей и ID Изера
        /// </summary>
        public IEnumerable<AppUserRoleViewModel> Roles { get; set; }


    }
}