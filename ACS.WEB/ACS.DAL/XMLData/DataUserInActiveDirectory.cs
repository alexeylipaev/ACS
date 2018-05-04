using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.XMLData
{
    class DataUserInActiveDirectory
    {
        PrincipalContext pc;
        public UserPrincipal UserPrincipal { get; private set; }
        public string Email { get; private set; }
        public string SID { get; private set; } = string.Empty;

        public DataUserInActiveDirectory()
        {
            try
            {
                pc = new PrincipalContext(ContextType.Domain);
            }
            catch (System.DirectoryServices.AccountManagement.PrincipalServerDownException ex)
            {
                Debug.Write("ERROR! " + ex.Message +"\n" + ex.Source);
                pc = null;
                return;
            }
            
        }
        public void SearchData(string lastName, string firstName)
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
    }
}
