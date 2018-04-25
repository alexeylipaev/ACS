using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    /// <summary>
    /// Данные  для  входа пользователя (т. е. Facebook, Google)
    /// </summary>
    public partial class  ASPLoginsIdentityUser : SystemParameters
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
        public virtual ASPIdentityUser IdentityUser { get; set; }

    }
}
