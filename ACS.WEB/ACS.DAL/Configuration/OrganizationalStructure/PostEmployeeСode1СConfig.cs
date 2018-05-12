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
    class PostEmployeeСode1СConfig : EntityTypeConfiguration<PostEmployeeСode1С>
    {
        public PostEmployeeСode1СConfig()
        {
            HasKey(e => e.id);

            Property(e => e.CodePost1C)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                new IndexAttribute("IX_CodePost1C") { IsUnique = true }));
        }
    }
}
