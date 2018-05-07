using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    internal class AppUserRoleConfig : EntityTypeConfiguration<AppUserRole>
    {
        public AppUserRoleConfig()
        {
            HasKey(e => new { e.RoleId , e.UserId});
           
        }
    }
}