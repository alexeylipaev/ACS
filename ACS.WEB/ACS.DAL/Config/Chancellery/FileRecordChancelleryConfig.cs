using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Config
{
    class FilesConfig : EntityTypeConfiguration<Files>
    {
        public FilesConfig()
        {

            Property(e => e.FileName)
                   .IsUnicode(true);
            //   .HasMaxLength(500)
            //.HasColumnAnnotation(IndexAnnotation.AnnotationName,
            //new IndexAnnotation(
            //new IndexAttribute("IX_NameFormat", 1) { IsUnique = true })); 

            Property(e => e.Extension)
                  .IsUnicode(true);
            //  .HasMaxLength(500)
            //.HasColumnAnnotation(IndexAnnotation.AnnotationName,
            //new IndexAnnotation(
            //new IndexAttribute("IX_NameFormat", 2) { IsUnique = true })); 

            Property(e => e.Path)
                .IsUnicode(true).IsRequired();

            HasMany(e => e.Chancelleries)
     .WithMany(e => e.FileRecordChancelleries);
        }
    }
}
