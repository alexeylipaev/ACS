using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class DataEntityConfig : EntityTypeConfiguration<DataEntity>
    {
        public DataEntityConfig()
        {
            HasKey(e => e.Id);

             Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
