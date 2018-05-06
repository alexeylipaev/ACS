using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class WorkHistoryConfig : EntityTypeConfiguration<WorkHistory>
    {
        public WorkHistoryConfig()
        {
            HasKey(e => e.id);

            Property(e => e.EndDate)
               .HasColumnType("date");

            Property(e => e.StartDate)
              .HasColumnType("date");
        }
    }
}
