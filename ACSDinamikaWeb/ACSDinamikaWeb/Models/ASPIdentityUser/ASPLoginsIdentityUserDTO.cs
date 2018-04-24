using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.Models
{
    public partial class ASPLoginsIdentityUserViewModel : SystemParametersViewModel
    {
    
        public int Id { get; set; }

        public string ProviderKey { get; set; }

        public string LoginProvider { get; set; }

        public virtual ASPIdentityUserViewModel IdentityUser { get; set; }

    }
}
