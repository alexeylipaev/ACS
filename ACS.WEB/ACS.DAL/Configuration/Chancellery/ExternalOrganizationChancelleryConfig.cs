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
    class ExternalOrganizationChancelleryConfig : EntityTypeConfiguration<ExternalOrganizationChancellery>
    {
        public ExternalOrganizationChancelleryConfig()
        {
            HasKey(e => e.id);

             Property(e => e.Name)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                new IndexAttribute("IX_Name") { IsUnique = true })); 

            Property(e => e.Address)
                .IsUnicode(true);

              Property(e => e.City)
                .IsUnicode(true);

             Property(e => e.Email)
                .IsUnicode(true);

             Property(e => e.Phone)
                .IsUnicode(true);

        }
    }
}
