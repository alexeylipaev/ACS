using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class TypeRecordChancelleryConfig : EntityTypeConfiguration<TypeRecordChancellery>
    {
        public TypeRecordChancelleryConfig()
        {
            HasKey(e => e.id);

            Property(e => e.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .IsUnicode(true).IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                new IndexAttribute("IX_Name") { IsUnique = true }));

            HasMany(e => e.Chancelleries)//имеет связанные обекты
    .WithRequired(e => e.TypeRecordChancellery)//Type  в сущности Chancellery не может быть null
    .WillCascadeOnDelete(false);//при удалении типа TypeRecordChancellery, не удалитять канцелярские записи
        }
    }
}
