using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.Models
{
    public partial class ASPRolesIdentityUserViewModel : SystemParametersViewModel
    {
        
        public int Id { get; set; }

        
        public string RoleId { get; set; }

       
        public string Name { get; set; }

        public virtual ASPIdentityUserViewModel IdentityUser { get; set; }

    }
}
