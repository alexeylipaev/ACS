using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Config
{
    class ChancelleryConfig : EntityTypeConfiguration<Chancellery>
    {
        public ChancelleryConfig()
        {

            Property(e => e.Status)
.IsUnicode(true);

            Property(e => e.Notice)
   .IsUnicode(true);

            Property(e => e.Summary)
               .IsUnicode(true);

            Property(e => e.RegistrationNumber)
               .IsUnicode(true);

            HasMany(e => e.ResponsibleEmployees)
                .WithMany(e => e.Chancelleries);

            HasMany(e => e.FileRecordChancelleries)
          .WithMany(e => e.Chancelleries);
        }
    }
}
