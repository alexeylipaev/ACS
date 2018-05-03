﻿using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class FolderChancelleryConfig : EntityTypeConfiguration<FolderChancellery>
    {
        public FolderChancelleryConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.Name)
                .IsUnicode(true).IsRequired();

            HasMany(e => e.Chancelleries)
            .WithOptional(e => e.FolderChancellery)
            .HasForeignKey(e => e.FolderId);
        }
    }
}