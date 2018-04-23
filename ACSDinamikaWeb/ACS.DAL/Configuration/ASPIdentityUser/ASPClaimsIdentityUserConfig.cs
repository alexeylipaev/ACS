using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{

    class ASPClaimsIdentityUserConfig: EntityTypeConfiguration<ASPClaimsIdentityUser>
    {
        public ASPClaimsIdentityUserConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.ClaimsId)
            .IsUnicode(false);

            Property(e => e.ClaimType)
            .IsUnicode(false);

            Property(e => e.ClaimValue)
            .IsUnicode(false);
        }
    }
}
