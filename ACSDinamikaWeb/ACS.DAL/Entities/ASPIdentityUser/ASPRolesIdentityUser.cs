using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Роли пользователя
    /// </summary>
    public partial class ASPRolesIdentityUser : SystemParameters
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Пользователи, которое владеют этой ролью
        /// </summary>
        public virtual ICollection<ASPIdentityUser> IdentityUser { get; set; }

    }
}
