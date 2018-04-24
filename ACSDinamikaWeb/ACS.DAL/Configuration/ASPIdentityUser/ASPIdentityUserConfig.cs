using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class ASPIdentityUserConfig : EntityTypeConfiguration<ASPIdentityUser>
    {
        public ASPIdentityUserConfig()
        {
            Property(e => e.IdentityUserName)
                .IsUnicode(false);

            Property(e => e.PasswordHash)
                .IsUnicode(false);

            Property(e => e.SecurityStamp)
              .IsUnicode(false);

            Property(e => e.EMail)
              .IsUnicode(false);
        }
    }
}
