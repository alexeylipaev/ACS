using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {

            Property(e => e.FName)
            .IsUnicode(false);


            Property(e => e.LName)
            .IsUnicode(false);


            Property(e => e.MName)
            .IsUnicode(false);


            Property(e => e.SID)
            .IsUnicode(false);

            HasMany(e => e.Accesses)
            .WithOptional(e => e.User)
            .WillCascadeOnDelete();

            // HasMany(e => e.PostUserСode1С)
            //.WithOptional(e => e.User)
            //.WillCascadeOnDelete();



            //HasOptional(e => e.Passport);

            //.HasForeignKey(e => e.ResponsibleUserId);
        }
    }
}
