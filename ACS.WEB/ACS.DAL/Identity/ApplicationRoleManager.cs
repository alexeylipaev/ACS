
using ACS.DAL.EF;
using ACS.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
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
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int> 
    {

        public ApplicationRoleManager(IRoleStore<ApplicationRole, int> store)
                    : base(store)
        { }



        public ApplicationRole FindById(int roleId)
        {
            return (from role in Roles
                    where role.Id == roleId
                    select role).FirstOrDefault();
        }

        public ApplicationRole FindByName(string roleName)
        {
            return (from role in Roles
                    where role.Name == roleName
                    select role).FirstOrDefault();
        }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
                                            IOwinContext context)
        {
            return new ApplicationRoleManager(new AppRoleStore(context.Get<ACSContext>()));
             
        }
        //public ApplicationRole FindByRoleDTO(ApplicationRoleDTO AppRoleDTO)
        //{
        //    return (from role in Roles
        //            where role.Name == AppRoleDTO.Name
        //            select role).FirstOrDefault();
        //}

        //public IEnumerable<ApplicationUser> FindAllAppUsersByRole(ApplicationRoleDTO AppRoleDTO)
        //{
        //    return FindById(AppRoleDTO.id.ToString()).Users.OfType<ApplicationUser>();
        //}

    }
}
