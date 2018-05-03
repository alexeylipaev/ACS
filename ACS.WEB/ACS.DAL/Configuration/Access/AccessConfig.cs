﻿using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{

    class AccessConfig : EntityTypeConfiguration<Access>
    {
        public AccessConfig()
        {
            HasKey(e => e.Id);
      
            Property(e => e.Note)
            .IsUnicode(true);

        }
    }
}