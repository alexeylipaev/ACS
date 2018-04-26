using ACS.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ACS.DAL.Configuration
{
    internal class ASPIdentityUserConfig : EntityTypeConfiguration<ASPIdentityUser>
    {
        public ASPIdentityUserConfig()
        {


            Property(e => e.UserName)
                .IsUnicode(true);

            Property(e => e.PasswordHash)
                .IsUnicode(true);

            Property(e => e.SecurityStamp)
                 .IsUnicode(true);

            Property(e => e.EMail)
                .IsUnicode(true);
        }
    }
}