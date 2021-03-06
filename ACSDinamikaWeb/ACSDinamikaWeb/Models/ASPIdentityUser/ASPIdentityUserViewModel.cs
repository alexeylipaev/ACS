﻿using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACSWeb.ViewModel
{
    public partial class ApplicationUserViewModel : SystemParametersViewModel
    {
        public ApplicationUserViewModel()
        {
            //Claims = new HashSet<ApplicationClaimDTO>();
            //Logins = new HashSet<ApplicationLoginDTO>();
            RolesID = new HashSet<int>();
        }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }


        public string Password { get; set; }

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
        //public virtual ICollection<ApplicationClaimDTO> Claims { get; set; }

        ///// <summary>
        ///// Логины (1 пользователь имеет N логинов (google, fb...))
        ///// </summary>
        //public virtual ICollection<ApplicationLoginDTO> Logins { get; set; }

        /// <summary>
        /// Роли N to N
        /// </summary>
        public virtual ICollection<int> RolesID { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        //public virtual UserDTO Employee { get; set; }

    }
}