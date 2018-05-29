using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACS.BLL.DTO
{
    public partial class ApplicationUserDTO
    {
        //public ApplicationUserDTO()
        //{
        //    Claims = new HashSet<AppUserClaimDTO>();
        //    Logins = new HashSet<AppUserLoginDTO>();
        //    Roles = new HashSet<AppUserRoleDTO>();
        //    //DataRoles = new HashSet<ApplicationRoleDTO>();
        //}

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
        public  IEnumerable<AppUserLoginDTO> Logins { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public  IEnumerable<AppUserRoleDTO> Roles { get; set; }

        //public virtual ICollection<ApplicationRoleDTO> DataRoles { get; set; }
    }
}