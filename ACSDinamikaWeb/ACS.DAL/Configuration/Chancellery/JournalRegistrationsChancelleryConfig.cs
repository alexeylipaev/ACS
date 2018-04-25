using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class JournalRegistrationsChancelleryConfig : EntityTypeConfiguration<JournalRegistrationsChancellery>
    {
        public JournalRegistrationsChancelleryConfig()
        {
            Property(e => e.Name)
               .IsUnicode(true);

            HasMany(e => e.Chancelleries)
                 .WithOptional(e => e.JournalRegistrationsChancellery)
             .HasForeignKey(e => e.JournalRegistrationsId);
        }
    }
}
