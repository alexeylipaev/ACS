using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
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
            HasKey(p => p.Id);//первичный ключ
            Property(p => p.Name).IsUnicode(true);//поддержка кирилицы

            HasMany(e => e.Accesses)//имеет связанные обекты
            .WithOptional(e => e.TypeAccess)//TypeAccess  в сущности Access может быть null
            .WillCascadeOnDelete();//при удалении типа TypeAccess, удалить все доступы Access
        }
    }
}
