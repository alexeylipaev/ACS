using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    /// <summary>
    /// Роли пользователя
    /// </summary>
    public partial class ApplicationRoleDTO : SystemParametersDTO
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Пользователи, которое владеют этой ролью
        /// </summary>
        //public virtual ICollection<ApplicationUserDTO> IdentityUser { get; set; }
    }
}
