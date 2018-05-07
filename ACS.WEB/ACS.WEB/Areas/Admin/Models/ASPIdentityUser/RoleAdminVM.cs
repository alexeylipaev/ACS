using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.Areas.Admin.Models
{
  public  class ApplicationRoleAdminVM
    {
        public ApplicationRoleAdminVM()
        {
            Users = new HashSet<AppUserRoleAdminVM>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Объект хранить в себе ID шники UserId и RoleId
        /// </summary>
        public ICollection<AppUserRoleAdminVM> Users { get; set; }
    }
}
