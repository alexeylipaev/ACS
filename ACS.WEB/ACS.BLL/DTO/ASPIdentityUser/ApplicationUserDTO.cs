﻿using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACS.BLL.DTO
{
    public partial class ApplicationUserDTO
    {
        public ApplicationUserDTO()
        {
            Claims = new HashSet<ApplicationClaimDTO>();
            Logins = new HashSet<ApplicationLoginDTO>();
            Roles = new HashSet<AppUserRoleDTO>();
        }

        public int Id { get; set; }

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
        /// Id пользователя
        /// </summary>
        public virtual EmployeeDTO Employee { get; set; }

        /// <summary>
        /// Свойство навигации для утверждений пользователя
        /// </summary>
        public virtual ICollection<ApplicationClaimDTO> Claims { get; set; }

        /// <summary>
        /// Логины (1 пользователь имеет N логинов (google, fb...))
        /// </summary>
        public virtual ICollection<ApplicationLoginDTO> Logins { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public virtual ICollection<AppUserRoleDTO> Roles { get; set; }

    }
}