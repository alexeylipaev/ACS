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
                .IsUnicode(true);

            HasMany(e => e.ChildrenDepartments)//отдел имеет ссылки на дочернии отделы
            .WithOptional(e => e.ParentDepartment)//ссылка на родительское подразделение может отсутствовать
             .HasForeignKey(e => e.ParentDepartmentId);
             //.WillCascadeOnDelete(true);//При удалении подразделения, удаляем дочернии
 
        }
    }
}
