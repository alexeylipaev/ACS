using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class TypeAccessConfig : EntityTypeConfiguration<TypeAccess>
 
    {
        public TypeAccessConfig()
        {
            //HasKey(e => new { e.Id, e.s_Guid });
            HasKey(e => e.Id);

            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    


            Property(p => p.Name).IsUnicode(true).IsRequired().HasMaxLength(50);
      
            HasMany(e => e.Accesses)//имеет связанные обекты
            .WithRequired(e => e.TypeAccess)//TypeAccess  в сущности Access не может быть null
            .WillCascadeOnDelete();//при удалении типа TypeAccess, удалить все доступы Access
        }
    }
}
