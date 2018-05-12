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
    class FileRecordChancelleryConfig : EntityTypeConfiguration<FileRecordChancellery>
    {
        public FileRecordChancelleryConfig()
        {
            HasKey(e => e.id);

            Property(e => e.Name)
                   .IsUnicode(true);
                //   .HasMaxLength(500)
                //.HasColumnAnnotation(IndexAnnotation.AnnotationName,
                //new IndexAnnotation(
                //new IndexAttribute("IX_NameFormat", 1) { IsUnique = true })); 

            Property(e => e.Format)
                  .IsUnicode(true);
                //  .HasMaxLength(500)
                //.HasColumnAnnotation(IndexAnnotation.AnnotationName,
                //new IndexAnnotation(
                //new IndexAttribute("IX_NameFormat", 2) { IsUnique = true })); 

            Property(e => e.Path)
                .IsUnicode(true).IsRequired();


        }
    }
}
