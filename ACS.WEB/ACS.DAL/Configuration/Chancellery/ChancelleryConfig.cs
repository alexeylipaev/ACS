using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.Configuration
{
    class ChancelleryConfig : EntityTypeConfiguration<Chancellery>
    {
        public ChancelleryConfig()
        {
            HasKey(e=>e.id);

            Property(e => e.Summary)
               .IsUnicode(true);

            Property(e => e.RegistrationNumber)
               .IsUnicode(true);

            //Property(p => p.DateRegistration).HasColumnType("date");
            //N:N
            HasMany(e => e.ResponsibleEmployees)
               .WithMany(e => e.Chancelleries);

            //1:N
            HasMany(e => e.FromChancelleries)//одна канцелярская запись может быть оформлена от N (обсуждали)
            .WithOptional(e => e.Chancellery)//в записи "от кого" может отсуствовать ссылка на канцелярскую запись
            //.HasForeignKey(e => e.ChancelleryId)//связываем по внешнему ключу ChancelleryId
            .WillCascadeOnDelete(false);//при удалении канцелярской записи, "от кого" не удаляем

            HasMany(e => e.ToChancelleries)
            .WithOptional(e => e.Chancellery)
       
            //.HasForeignKey(e => e.ChancelleryId)
            .WillCascadeOnDelete(false);
        }
    }
}
