using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.ViewModels
{
    public partial class AppUserClaimViewModel
    {
        public int id { get; set; }
        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public int? UserId { get; set; }

    }
}
