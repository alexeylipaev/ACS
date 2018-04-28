using ACS.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ACS.DAL.Configuration
{
    internal class ApplicationUserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfig()
        {


            Property(e => e.UserName)
                .IsUnicode(true);

            Property(e => e.PasswordHash)
                .IsUnicode(true);

            Property(e => e.SecurityStamp)
                 .IsUnicode(true);

            Property(e => e.Email)
                .IsUnicode(true);
        }
    }
}