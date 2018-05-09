using ACS.DAL.Entities;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class ProjectRegistryConfig : EntityTypeConfiguration<ProjectRegistry>
    {
        public ProjectRegistryConfig()
        {
            HasKey(e => e.Id);
            Property(e => e.PlanStartDate)
           .HasColumnType("date");
            Property(e => e.PlanEndDate)
     .HasColumnType("date");
            Property(e => e.ActualStartDate)
   .HasColumnType("date");
            Property(e => e.ActualEndDate)
    .HasColumnType("date");
            Property(e => e.DateOfSubmissionWorkSchedulePlan)
   .HasColumnType("date");
        }
    }
}
