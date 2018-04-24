using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    public partial class ASPRolesIdentityUserDTO : SystemParametersDTO
    {
        
        public int Id { get; set; }

        
        public string RoleId { get; set; }

       
        public string Name { get; set; }

        public virtual ASPIdentityUserDTO IdentityUser { get; set; }

    }
}
