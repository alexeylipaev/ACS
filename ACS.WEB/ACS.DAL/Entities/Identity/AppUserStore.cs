using ACS.DAL.EF;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Entities
{
    public class AppUserStore : UserStore<ApplicationUser, ApplicationRole, int,
        AppUserLogin, AppUserRole, AppUserClaim>
    {
        
        public AppUserStore(ACSContext context)
            : base(context)
        {
        }
    }
}
