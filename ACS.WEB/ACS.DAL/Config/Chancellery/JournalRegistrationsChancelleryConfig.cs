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
    class JournalRegistrationsChancelleryConfig : EntityTypeConfiguration<JournalRegistrationsChancellery>
    {
        public JournalRegistrationsChancelleryConfig()
        {
            Property(e => e.Name)
               .IsUnicode(true).IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                new IndexAttribute("IX_Name") { IsUnique = true }));

            HasMany(e => e.Chancelleries)
                 .WithOptional(e => e.JournalRegistrationsChancellery);
             //.HasForeignKey(e => e.JournalRegistrationsId);
        }
    }
}
