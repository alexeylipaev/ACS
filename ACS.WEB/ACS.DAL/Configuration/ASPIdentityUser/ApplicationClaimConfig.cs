using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{

    class ApplicationClaimConfig: EntityTypeConfiguration<ApplicationClaim>
    {
        public ApplicationClaimConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.ClaimType)
            .IsUnicode(true);

            Property(e => e.ClaimValue)
            .IsUnicode(true);

        }
    }
}
