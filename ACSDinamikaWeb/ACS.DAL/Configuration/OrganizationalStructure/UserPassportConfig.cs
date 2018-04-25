using ACS.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ACS.DAL.Configuration
{
    internal class UserPassportConfig : EntityTypeConfiguration<UserPassport>
    {
        public UserPassportConfig()
        {

            Property(e => e.Series)
                .IsUnicode(true);

            Property(e => e.Number)
                .IsUnicode(true);

           Property(e => e.IssuedBy)
                .IsUnicode(true);

            Property(e => e.UnitCode)
                .IsUnicode(true);

        }
    }
}