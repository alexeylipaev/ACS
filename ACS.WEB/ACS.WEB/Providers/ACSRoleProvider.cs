using ACS.BLL;
using ACS.BLL.DTO;
using ACS.BLL.Interfaces;
using ACS.BLL.Services;


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ACS.WEB.Providers
{
    /// <summary>
    ///  Провайдер для очень простенькой системы авторизации.
    ///  Когда  не нужны все навороты ASP.NET Identity
    /// </summary>
    public class ACSRoleProvider : RoleProvider
    {

        //SecurityService _SecurityService;
        //SecurityService SecurityService
        //{
        //    get
        //    {
        //        if (_SecurityService == null)
        //            _SecurityService = new SecurityService(new EFUnitOfWork(ConfigurationManager.ConnectionStrings["ACSContextConnection"].ConnectionString));
        //        return _SecurityService;
        //    }
        //}

        IApplicationUserService ApplicationUserService;

        public ACSRoleProvider()
        {
            //use the service locator pattern.
            //The service locator pattern is normally considered to be an anti-pattern
            //для  Ninject. Следующий код должен работать.
            ApplicationUserService = DependencyResolver.Current.GetService<IApplicationUserService>();

        }

       
       
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  получить набор ролей для определенного пользователя
        /// </summary>
        /// <param name="domainUsername"></param>
        /// <returns></returns>
        public override string[] GetRolesForUser(string domainUsername)
        {
            string Email = ActiveDirectory.IdentityUserEmailFromActiveDirectory(domainUsername);
            //находим пользователя по его Email
            var applicationUserDTO = ApplicationUserService.FindByEmail(Email);//SecurityService.GetIdentityUser(Email);

            List<string> result = new List<string>();
            foreach (var roleId in applicationUserDTO.RolesId)
            {
                var role = ApplicationUserService.FindRoleById(roleId);
                if (role != null)
                    result.Add(role.Id.ToString());
            }
            return result.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {

            return ApplicationUserService.IsInRole(username, roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}