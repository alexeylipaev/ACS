using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class ASPRolesIdentityUserConfig : EntityTypeConfiguration<ASPRolesIdentityUser>
    {
        public ASPRolesIdentityUserConfig()
        {
            Property(e => e.RoleId)
.IsUnicode(true);

            Property(e => e.Name)
              .IsUnicode(true);

        }
    }
}
