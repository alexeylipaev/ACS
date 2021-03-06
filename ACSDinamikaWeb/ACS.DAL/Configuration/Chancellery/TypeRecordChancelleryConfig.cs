﻿using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class TypeRecordChancelleryConfig : EntityTypeConfiguration<TypeRecordChancellery>
    {
        public TypeRecordChancelleryConfig()
        {
               Property(e => e.Name)
                .IsUnicode(true);

            HasMany(e => e.Chancelleries)
             .WithOptional(e => e.TypeRecordChancellery)
               .HasForeignKey(e => e.TypeRecordId).WillCascadeOnDelete(false);
        }
    }
}
