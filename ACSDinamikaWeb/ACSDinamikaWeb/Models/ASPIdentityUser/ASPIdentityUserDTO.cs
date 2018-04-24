using System;
using System.Collections.Generic;


using System.Linq;
using System.Web;

namespace ACSWeb.Models
{
    public partial class ASPIdentityUserViewModel : SystemParametersViewModel
    {
        public ASPIdentityUserViewModel()
        {
            Claims = new HashSet<ASPClaimsIdentityUserViewModel>();
            Logins = new HashSet<ASPLoginsIdentityUserViewModel>();
            Roles = new HashSet<ASPRolesIdentityUserViewModel>();
        }

        public string IdentityUserName { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string EMail { get; set; }

        public virtual ICollection<ASPClaimsIdentityUserViewModel> Claims { get; set; }

        public virtual ICollection<ASPLoginsIdentityUserViewModel> Logins { get; set; }

        public virtual ICollection<ASPRolesIdentityUserViewModel> Roles { get; set; }

    }
}