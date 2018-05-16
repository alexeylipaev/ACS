using ACS.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ACS.DAL.Configuration
{
    class EmployeeConfig : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfig()
        {
            HasKey(e => e.id);

            Property(e => e.FName)
            .IsUnicode(true)/*.IsRequired()*/;

            Property(e => e.LName)
            .IsUnicode(true);

            Property(e => e.MName)
            .IsUnicode(true);

            Property(e => e.Birthday)
            .HasColumnType("date");

            Property(e => e.SID)
            .IsUnicode(true);

            //HasMany(e => e.Chancelleries)
            //.WithOptional(e => e.ResponsibleEmployees)
            ////.HasForeignKey(e => e.ResponsibleEmployeeId)
            //.WillCascadeOnDelete(false);//при удалении пользователя, канцелярию где он ответственный не удаляем

            HasMany(e => e.Accesses)
            .WithOptional(e => e.Employee)
              //.HasForeignKey(e => e.EmployeeId)
            .WillCascadeOnDelete(true);

            HasMany(e => e.PostsEmployeesСode1С)
           .WithOptional(e => e.Employee)
           //.HasForeignKey(e => e.EmployeeId)
           .WillCascadeOnDelete(true);
        }
    }
}
