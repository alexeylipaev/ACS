﻿using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class PostNameEmployeeConfig : EntityTypeConfiguration<PostNameEmployee>
    {
        public PostNameEmployeeConfig()
        {
            HasKey(e => e.id);

            Property(e => e.Name)
                .IsUnicode(true).IsRequired();
        }
    }
}
