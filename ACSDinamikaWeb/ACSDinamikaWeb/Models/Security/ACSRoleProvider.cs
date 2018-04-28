using ACS.BLL.DTO;
using ACS.BLL.Interfaces;
using ACS.BLL.Services;
using ACS.DAL.Repositories;
using ACSWeb.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ACSWeb.Models.Security
{
    public class ACSRoleProvider : RoleProvider
    {

        SecurityService _SecurityService;
        SecurityService SecurityService
        { get {
                if(_SecurityService == null )
                 _SecurityService = new SecurityService(new EFUnitOfWork(ConfigurationManager.ConnectionStrings["ACSContextConnection"].ConnectionString));
                return _SecurityService;
            }
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

        public override string[] GetRolesForUser(string username)
        {
            string email = ActiveDirectory.IdentityUserEmailFromActiveDirectory(username);
            var applicationUserDTO = SecurityService.GetIdentityUser(email);

            List<string> result = new List<string>();
            foreach (var roleId in applicationUserDTO.RolesID)
            {
                result.Add(SecurityService.GetRoleById(roleId));
            }
            var rolesDTO =  SecurityService.GetRoles.Find(u=>userDTO.RolesID.Contains(u.Id)).Select(u=> u.Name );
            //string[] rolesDTO = new string []{ "Administrators" };
            if (rolesDTO != null)
                return rolesDTO.ToArray();
            else
                return new string[] { }; ;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return SecurityService.IsUserInRoleAsync(username, roleName);
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