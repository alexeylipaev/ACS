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
   internal class EntityConfig : EntityTypeConfiguration<Entity>
    {
        public EntityConfig()
        {
            //HasKey(e => e.Id);

            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.s_Guid);

            Property(e => e.s_Guid).IsRequired()
    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
    new IndexAnnotation(
    new IndexAttribute("IX_s_Guid") { IsUnique = true }))
    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
