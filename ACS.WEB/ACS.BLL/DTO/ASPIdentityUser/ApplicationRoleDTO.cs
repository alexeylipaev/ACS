using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
  public  class ApplicationRoleDTO
    {
        public ApplicationRoleDTO()
        {
            Users = new HashSet<AppUserRoleDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Объект хранить в себе ID шники UserId и RoleId
        /// </summary>
        public ICollection<AppUserRoleDTO> Users { get; set; }
    }
}
