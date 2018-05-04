using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Web;

namespace ACS.BLL
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

        public static SearchResultCollection FindAccountByEmail(string pEmailAddress)
        {
            string filter = string.Format("(proxyaddresses=SMTP:{0})", pEmailAddress);

            using (DirectoryEntry gc = new DirectoryEntry("LDAP:"))
            {
                foreach (DirectoryEntry z in gc.Children)
                {
                    using (DirectoryEntry root = z)
                    {
                        using (DirectorySearcher searcher = new DirectorySearcher(root, filter, new string[] { "proxyAddresses", "objectGuid", "displayName", "distinguishedName" }))
                        {
                            searcher.ReferralChasing = ReferralChasingOption.All;
                            SearchResultCollection result = searcher.FindAll();

                            return result;
                        }
                    }
                }
            }
            return null;
        }

        public static string SearchForMailInAD(string email)
        {
            DirectorySearcher adSearcher = new DirectorySearcher();
            adSearcher.Filter = ("mail=" + email);
            SearchResult coll = adSearcher.FindOne();
            if (coll != null)
            {
                DirectoryEntry de = coll.GetDirectoryEntry();
               
                return de.Properties["sAMAccountName"].Value.ToString();
            }
            return null;
            //foreach (SearchResult item in coll)
            //{
            //    foundUsers_listBox.Items.Add(item.GetDirectoryEntry());
            //}
        }
    }
}