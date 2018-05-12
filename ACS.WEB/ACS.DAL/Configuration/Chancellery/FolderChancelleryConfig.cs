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
    class FolderChancelleryConfig : EntityTypeConfiguration<FolderChancellery>
    {
        public FolderChancelleryConfig()
        {
            HasKey(e => e.id);

            Property(e => e.Name)
                .IsUnicode(true).IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                new IndexAttribute("IX_Name") { IsUnique = true })); 

            HasMany(e => e.Chancelleries)
            .WithOptional(e => e.FolderChancellery);
            //.HasForeignKey(e => e.FolderId);
        }
    }
}
