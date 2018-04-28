using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class UserConfig : EntityTypeConfiguration<Employee>
    {
        public UserConfig()
        {

            Property(e => e.FName)
            .IsUnicode(true);


            Property(e => e.LName)
            .IsUnicode(true);


            Property(e => e.MName)
            .IsUnicode(true);


            Property(e => e.SID)
            .IsUnicode(true);

            HasMany(e => e.Chancelleries)
            .WithOptional(e => e.Employee)
            .HasForeignKey(e => e.ResponsibleUserId)
            .WillCascadeOnDelete(false);//при удалении пользователя, канцелярию где он ответственный не удаляем

            HasMany(e => e.Accesses)
            .WithOptional(e => e.Employee)
              .HasForeignKey(e => e.UserId)
            .WillCascadeOnDelete(false);

            HasMany(e => e.PostsEmployeesСode1С)
           .WithOptional(e => e.Employee)
           .HasForeignKey(e => e.UserId)
           .WillCascadeOnDelete();

        }
    }
}
