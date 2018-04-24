using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    public partial class  ASPLoginsIdentityUser : SystemParameters
    {
        public ASPLoginsIdentityUser()
        {

        }
        public int Id { get; set; }

        public string ProviderKey { get; set; }

        public string LoginProvider { get; set; }

        public virtual ASPIdentityUser IdentityUser { get; set; }

    }
}
