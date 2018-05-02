using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
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
            HasKey(e => e.Id);

             Property(e => e.Name)
                .IsUnicode(true).IsRequired();

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
