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

        /// <summary>
        /// Ключ, представляющий имя входа для поставщика
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        /// Поставщик входа в систему (например, Facebook, Google)
        /// </summary>
        public string LoginProvider { get; set; }


        public int? IdentityUserId { get; set; }

        /// <summary>
        /// Владелец this логина
        /// </summary>
        //public virtual ASPIdentityUserDTO IdentityUser { get; set; }

    }
}
