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
            //получаем емайл авторизованного пользователя по ActiveDirectory
            string email = ActiveDirectory.IdentityUserEmailFromActiveDirectory(username);
            var userDTO = SecurityService.GetIdentityUser(email);
            if (userDTO != null)
            {
                var rolesDTO = SecurityService.Find(u => userDTO.RolesID != null && userDTO.RolesID.Contains(u.Id));
                //string[] rolesDTO = new string []{ "Administrators" };
                if (rolesDTO != null)
                    return rolesDTO.Select(u => u.Name).ToArray();
            }
                return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return SecurityService.IsUserInRole(username, roleName);
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