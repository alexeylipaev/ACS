﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.ViewModel
{
    public partial class ApplicationLoginViewModel : SystemParametersViewModel
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


        public int? IdentityEmployeeId { get; set; }

        /// <summary>
        /// Владелец this логина
        /// </summary>
        //public virtual ApplicationUserViewModel IdentityUser { get; set; }

    }
}
