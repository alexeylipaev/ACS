using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Config
{
    class EmployeeConfig : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfig()
        {
            Property(e => e.FName)
            .IsUnicode(true)/*.IsRequired()*/;

            Property(e => e.LName)
            .IsUnicode(true);

            Property(e => e.MName)
            .IsUnicode(true);

            HasOptional(o => o.ApplicationUser)
.WithOptionalPrincipal(o => o.Employee);

            HasMany(e => e.Chancelleries)
            .WithMany(e => e.ResponsibleEmployees);

        }
    }
}
