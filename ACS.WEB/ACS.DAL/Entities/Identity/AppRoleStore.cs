using ACS.DAL.EF;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ACS.DAL.Entities
{
    public class AppRoleStore : RoleStore<ApplicationRole, int, AppUserRole>
    {
        public AppRoleStore(ACSContext context)
            : base(context)
        {
        }
    }
}
