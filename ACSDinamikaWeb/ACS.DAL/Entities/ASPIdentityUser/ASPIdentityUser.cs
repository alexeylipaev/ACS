using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACS.DAL.Entities
{

    public partial class ASPIdentityUser : SystemParameters
    {
        public ASPIdentityUser()
        {
            Claims = new HashSet<ASPClaimsIdentityUser>();
            Logins = new HashSet<ASPLoginsIdentityUser>();
            Roles = new HashSet<ASPRolesIdentityUser>();
        }
        /// <summary>
        /// Идентификатор пользователя (первичный ключ)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Начальная и хэшированная формы пароля пользователя
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Случайное значение, которое должно меняться при изменении учетных данных пользователя 
        /// (смена пароля, удаление имени входа)
        /// </summary>
        [Required]
        public string SecurityStamp { get; set; }

        [Index("EMail_Index", IsUnique = true)]
        [StringLength(100)]
        [Required]
        public string EMail { get; set; }

        /// <summary>
        /// Свойство навигации для утверждений пользователя
        /// </summary>
        public virtual ICollection<ASPClaimsIdentityUser> Claims { get; set; }

        /// <summary>
        /// Логины (1 пользователь имеет N логинов (google, fb...))
        /// </summary>
        public virtual ICollection<ASPLoginsIdentityUser> Logins { get; set; }

        /// <summary>
        /// Роли N to N
        /// </summary>
        public virtual ICollection<ASPRolesIdentityUser> Roles { get; set; }

        /***************** 1 to 1  ASPIdentityUser to User *********************/

        /// <summary>
        /// Id пользователя
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public virtual User User { get; set; }

    }
}