using Microsoft.AspNet.Identity.EntityFramework;


namespace ACS.DAL.Entities
{
    /// <summary>
    /// Промежуточная таблица хранит в себе UserId и RoleId
    /// </summary>
    public class AppUserRole : IdentityUserRole<int> { }

}
