using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class UserPassportConfig : EntityTypeConfiguration<UserPassport>
    {
        public UserPassportConfig()
        {
            Property(e => e.Series)
            .IsUnicode(false);


            Property(e => e.Number)
            .IsUnicode(false);


            Property(e => e.IssuedBy)
            .IsUnicode(false);


            Property(e => e.UnitCode)
            .IsUnicode(false);
        }
    }
}
