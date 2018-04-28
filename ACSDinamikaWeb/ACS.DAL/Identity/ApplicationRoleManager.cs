using ACS.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Identity
{
    /// <summary>
    /// Это стандартные для ASP.NET Identity классы по управлению ролями и пользователями. По сути эти классы выполняют роль репозиториев.
    /// </summary>
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(Microsoft.AspNet.Identity.EntityFramework.RoleStore<ApplicationRole> store)
                    : base(store)
        { }
    }
}
