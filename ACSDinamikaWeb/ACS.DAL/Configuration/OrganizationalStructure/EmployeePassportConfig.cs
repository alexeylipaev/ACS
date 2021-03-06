﻿using ACS.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ACS.DAL.Configuration
{
    internal class EmployeePassportConfig : EntityTypeConfiguration<EmployeePassport>
    {
        public EmployeePassportConfig()
        {

            Property(e => e.Series)
                .IsUnicode(true);

            Property(e => e.Number)
                .IsUnicode(true);

           Property(e => e.IssuedBy)
                .IsUnicode(true);

            Property(e => e.UnitCode)
                .IsUnicode(true);

        }
    }
}