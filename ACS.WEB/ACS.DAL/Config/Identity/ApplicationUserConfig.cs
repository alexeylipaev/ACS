﻿using ACS.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ACS.DAL.Config
{
    internal class ApplicationUserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.UserName)
                .IsUnicode(true);

            Property(e => e.PasswordHash)
                .IsUnicode(true);

            Property(e => e.SecurityStamp)
                 .IsUnicode(true);

            Property(e => e.Email)
                .IsUnicode(true).IsRequired();



            //HasMany(p => p.Roles).WithRequired().HasForeignKey(p => p.UserId);
        }
    }
}