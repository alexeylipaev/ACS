﻿using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class PostNameUserConfig : EntityTypeConfiguration<PostNameEmployee>
    {
        public PostNameUserConfig()
        {
               Property(e => e.Name)
                .IsUnicode(true);
        }
    }
}
