using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class ASPLoginsIdentityUserConfig : EntityTypeConfiguration<ASPLoginsIdentityUser>
    {
        public ASPLoginsIdentityUserConfig()
        {
             Property(e => e.ProviderKey)
                .IsUnicode(true);

            Property(e => e.LoginProvider)
              .IsUnicode(true);
        }
    }
}
