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
             Property(e => e.Name)
                .IsUnicode(false);

              Property(e => e.Address)
                .IsUnicode(false);

              Property(e => e.City)
                .IsUnicode(false);

             Property(e => e.Email)
                .IsUnicode(false);

             Property(e => e.Phone)
                .IsUnicode(false);

        }
    }
}
