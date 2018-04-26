using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.ViewModel
{
    public partial class ASPClaimsIdentityUserViewModel : SystemParametersViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Тип утверждения
        /// </summary>
        public string ClaimType { get; set; }

        /// <summary>
        /// Значение утверждения
        /// </summary>
        public string ClaimValue { get; set; }


        public int? IdentityUserId { get; set; }

        public virtual ASPIdentityUserViewModel IdentityUser { get; set; }

    }
}
