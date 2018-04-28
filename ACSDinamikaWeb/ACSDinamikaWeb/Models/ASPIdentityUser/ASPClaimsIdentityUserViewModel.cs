using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.ViewModel
{
    public partial class ApplicationClaimViewModel : SystemParametersViewModel
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


        public int? IdentityEmployeeId { get; set; }

        //public virtual ApplicationUserViewModel IdentityUser { get; set; }

    }
}
