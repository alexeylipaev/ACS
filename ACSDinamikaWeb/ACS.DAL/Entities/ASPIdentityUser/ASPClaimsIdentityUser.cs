using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    public partial class ASPClaimsIdentityUser : SystemParameters
    {
        [Key]
        public int Id { get; set; }

        public string ClaimsId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public virtual ASPIdentityUser IdentityUser { get; set; }

    }
}
