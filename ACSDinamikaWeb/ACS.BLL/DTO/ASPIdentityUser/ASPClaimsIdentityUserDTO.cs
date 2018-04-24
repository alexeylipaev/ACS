using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    public partial class ASPClaimsIdentityUserDTO : SystemParametersDTO
    {
        public int Id { get; set; }

        public string ClaimsId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public virtual ASPIdentityUserDTO IdentityUser { get; set; }

    }
}
