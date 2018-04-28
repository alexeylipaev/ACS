using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACS.BLL.DTO
{
    public partial class ASPIdentityUserDTO : SystemParametersDTO
    {
        public ASPIdentityUserDTO()
        {
            //Claims = new HashSet<ASPClaimsIdentityUserDTO>();
            //Logins = new HashSet<ASPLoginsIdentityUserDTO>();
            //Roles = new HashSet<ASPRolesIdentityUserDTO>();
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

        public string Email { get; set; }

        public string SID { get; set; }

        ///// <summary>
        ///// Свойство навигации для утверждений пользователя
        ///// </summary>
        //public virtual ICollection<ASPClaimsIdentityUserDTO> Claims { get; set; }

        ///// <summary>
        ///// Логины (1 пользователь имеет N логинов (google, fb...))
        ///// </summary>
        //public virtual ICollection<ASPLoginsIdentityUserDTO> Logins { get; set; }

        /// <summary>
        /// Роли N to N
        /// </summary>
        public virtual ICollection<int> RolesID { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        //public virtual UserDTO User { get; set; }

    }
}