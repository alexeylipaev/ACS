using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Config
{
    class ApplicationRoleConfig : EntityTypeConfiguration<ApplicationRole>
    {
        public ApplicationRoleConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.Name)
              .IsUnicode(true).IsRequired();


            //HasMany(p => p.Users).WithRequired().HasForeignKey(p => p.RoleId);

        }
    }
}
