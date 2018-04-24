using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACS.BLL.DTO
{
    public partial class ASPIdentityUserDTO : SystemParametersDTO
    {
        public ASPIdentityUserDTO()
        {
            Claims = new HashSet<ASPClaimsIdentityUserDTO>();
            Logins = new HashSet<ASPLoginsIdentityUserDTO>();
            Roles = new HashSet<ASPRolesIdentityUserDTO>();
        }

        public string IdentityUserName { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string EMail { get; set; }

        public virtual ICollection<ASPClaimsIdentityUserDTO> Claims { get; set; }

        public virtual ICollection<ASPLoginsIdentityUserDTO> Logins { get; set; }

        public virtual ICollection<ASPRolesIdentityUserDTO> Roles { get; set; }

    }
}