using ACS.DAL.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ACS.DAL.Entities
{
    /// <summary>
    ///  You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /// </summary>
    public partial class ApplicationUser : IdentityUser<int, AppUserLogin, AppUserRole,
    AppUserClaim>
    {

        //public ApplicationUser()
        //{
        //    DataRoles = new HashSet<ApplicationRole>();

        //}


        //private void FillDataRoles()
        //{
        //    using (EFUnitOfWork context = new EFUnitOfWork(Сonnection.@string))
        //    {
        //        for (int i = 0; i < this.Roles.Count; i++)
        //        {
        //            var roleId = this.Roles.ElementAt(i).RoleId;

        //            var role = context.RoleManager.FindById(roleId);
        //            if (!DataRoles.Any(dr => dr.Name == role.Name))
        //                this.DataRoles.Add(role);
        //        }
        //    }
        //}

            //public int? Employee_Id { get; set; }

        public virtual Employee Employee { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
    UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }


        //[NotMapped]
        //public ICollection<ApplicationRole> DataRoles { get; set; }
        //{
        //    get
        //    {
        //        FillDataRoles();
        //        return DataRoles;
        //    }
        //    private set { }
        //}
        //public string UserName { get; set; }

    }

}