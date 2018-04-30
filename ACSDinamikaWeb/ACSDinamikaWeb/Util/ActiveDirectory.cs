using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

namespace ACSWeb.Util
{
    public class ActiveDirectory
    {
        public static string IdentityUserEmailFromActiveDirectory(string identityName)
        {
            PrincipalContext pc = new PrincipalContext(ContextType.Domain);
            UserPrincipal up = UserPrincipal.FindByIdentity(pc, identityName);
            //EmployeeService.GetUser
            return up.EmailAddress;
        }
    }
}