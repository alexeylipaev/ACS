using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.DTO
{
    public partial class ApplicationClaimDTO : SystemParametersDTO
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

        //public virtual ApplicationUserDTO IdentityUser { get; set; }

    }
}
