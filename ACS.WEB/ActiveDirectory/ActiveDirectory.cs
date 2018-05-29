using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Web;

namespace ActiveDirectory
{
    public class DataActiveDirectory
    {
        static PrincipalContext pc;
        public UserPrincipal UserPrincipal { get; private set; }
        public string Email { get; private set; }
        public string SID { get; private set; } = string.Empty;
        static DataActiveDirectory()
        {
            try
            {
                pc = new PrincipalContext(ContextType.Domain);
            }
            catch (System.DirectoryServices.AccountManagement.PrincipalServerDownException ex)
            {
                Debug.Write("ERROR! " + ex.Message + "\n" + ex.Source);
                pc = null;
                return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityName"></param>
        /// <returns></returns>
        public static string IdentityUserEmailFromActiveDirectory(string identityName)
        {
            if (pc == null) return string.Empty;
            UserPrincipal up = null;
            try
            {
                up = UserPrincipal.FindByIdentity(pc, identityName);
            }
            catch (MultipleMatchesException)
            {
                Debug.Write(string.Format("в групповой политеке {0} {1}  имеется больше одного  ", identityName));
            }

            //EmployeeService.GetUser
            return up.EmailAddress;
        }

        public void SearchDataByLNameAndFName(string lastName, string firstName)
        {
            UserPrincipal up = null;
            if (pc == null) return;
            try
            {
                up = UserPrincipal.FindByIdentity(pc, IdentityType.Name, string.Format("{0} {1}", lastName, firstName));
            }
            catch (MultipleMatchesException)
            {
                up = null;
                Debug.Write(string.Format("в групповой политеке {0} {1}  имеется больше одного  ", lastName, firstName));
            }

            UserPrincipal = up;
            if (UserPrincipal != null)
            {
                Email = UserPrincipal.EmailAddress;
                SID = UserPrincipal.Sid.ToString();
            }
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
