using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// EntityType, представляющий одно определенное утверждение пользователя
    /// </summary>
    public partial class ASPClaimsIdentityUser : SystemParameters
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Тип утверждения
        /// </summary>
        public string ClaimType { get; set; }

        /// <summary>
        /// Значение утверждения
        /// </summary>
        public string ClaimValue { get; set; }


        public int? IdentityUserId { get; set; }

        /// <summary>
        /// Свойство навигации, задающее внешний ключ для пользователя
        /// </summary>
        public virtual ASPIdentityUser IdentityUser { get; set; }

    }
}
