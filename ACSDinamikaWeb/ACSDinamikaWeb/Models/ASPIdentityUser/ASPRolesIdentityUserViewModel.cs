﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSWeb.ViewModel
{
    /// <summary>
    /// Роли пользователя
    /// </summary>
    public partial class ASPRolesIdentityUserViewModel : SystemParametersViewModel
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Пользователи, которое владеют этой ролью
        /// </summary>
        public virtual ICollection<ASPIdentityUserViewModel> IdentityUser { get; set; }
    }
}
