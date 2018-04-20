using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitializingDBFromXML.Model
{
    class DataUserInActiveDirectory
    {
        PrincipalContext pc;
        public UserPrincipal UserPrincipal { get; private set; }
        public string Email { get; private set; }
        public string SID { get; private set; }

        public DataUserInActiveDirectory()
        {
            pc = new PrincipalContext(ContextType.Domain);
        }
        public void SearchData(string lastName, string firstName)
        {
            UserPrincipal up = UserPrincipal.FindByIdentity(pc, IdentityType.Name, string.Format("{0} {1}", lastName, firstName));

            UserPrincipal = up;
            if (UserPrincipal != null)
            {
                Email = UserPrincipal.EmailAddress;
                SID = UserPrincipal.Sid.ToString();
            }
        }
    }
}
