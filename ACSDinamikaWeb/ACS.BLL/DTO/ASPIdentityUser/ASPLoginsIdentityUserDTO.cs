using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    public partial class ASPLoginsIdentityUserDTO : SystemParametersDTO
    {
    
        public int Id { get; set; }

        public string ProviderKey { get; set; }

        public string LoginProvider { get; set; }

        public virtual ASPIdentityUserDTO IdentityUser { get; set; }

    }
}
