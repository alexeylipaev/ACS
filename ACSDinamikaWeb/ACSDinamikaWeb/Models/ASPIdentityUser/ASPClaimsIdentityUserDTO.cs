using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.Models
{
    public partial class ASPClaimsIdentityUserViewModel : SystemParametersViewModel
    {
        public int Id { get; set; }

        public string ClaimsId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public virtual ASPIdentityUserViewModel IdentityUser { get; set; }

    }
}
