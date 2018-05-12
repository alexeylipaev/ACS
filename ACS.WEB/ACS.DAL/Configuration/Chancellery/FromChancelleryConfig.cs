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
    class FromChancelleryConfig : EntityTypeConfiguration<FromChancellery>
    {
        public FromChancelleryConfig()
        {
            HasKey(e => e.id);

            //Property(p => p.Chancellery.id)
            //    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
            //    new IndexAnnotation(
            //    new IndexAttribute("IX_Chancellery_Id", 1) { IsUnique = true }));
        }
    }
}
