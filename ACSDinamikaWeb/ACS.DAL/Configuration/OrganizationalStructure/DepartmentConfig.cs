using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class DepartmentConfig : EntityTypeConfiguration<Department>
    {
        public DepartmentConfig()
        {
                Property(e => e.Name)
                .IsUnicode(false);

            HasMany(e => e.ChildrenDepartments)
            .WithOptional(e => e.ParentDepartment);
               // .HasForeignKey(e => e.ParentDepartmentId);
        }
    }
}
