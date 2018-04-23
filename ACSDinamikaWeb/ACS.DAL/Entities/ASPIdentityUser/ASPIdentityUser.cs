using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACS.DAL.Entities
{
    [ComplexType]
    public partial class ASPIdentityUser : SystemParameters
    {
        public ASPIdentityUser()
        {
            Claims = new HashSet<ASPClaimsIdentityUser>();
            Logins = new HashSet<ASPLoginsIdentityUser>();
            Roles = new HashSet<ASPRolesIdentityUser>();
        }

        [Required]
        public string IdentityUserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string SecurityStamp { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        public virtual ICollection<ASPClaimsIdentityUser> Claims { get; set; }

        public virtual ICollection<ASPLoginsIdentityUser> Logins { get; set; }

        public virtual ICollection<ASPRolesIdentityUser> Roles { get; set; }

    }
}