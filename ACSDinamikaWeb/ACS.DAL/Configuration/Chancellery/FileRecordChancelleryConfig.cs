using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
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
            Property(e => e.Name)
                   .IsUnicode(false);

            Property(e => e.format)
                  .IsUnicode(false);

            Property(e => e.Path)
                .IsUnicode(false);

        }
    }
}
