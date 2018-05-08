using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.EF
{

    public class MobileContext : DbContext
    {
      

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }

        static MobileContext()
        {
            //Стратегии инициализации БД
            //Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<MobileContext>());
            //Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseAlways<MobileContext>());
            //Database.SetInitializer(new System.Data.Entity.CreateDatabaseIfNotExists<MobileContext>());

            ////Используется CodeFirst Migrations
            Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<MobileContext, NLayerApp.DAL.Migrations.Configuration>());
            //Database.SetInitializer<MobileContext>(new StoreDbInitializer());
        }
        //public MobileContext(string connectionString = "DefaultConnection")
        //    : base(connectionString)
        //{
        //}
        public MobileContext() 
            : base() { }

        public MobileContext(string connectionString = "DefaultConnection")
            : base(connectionString) { }

        public MobileContext(DbConnection existingConnection, bool contextOwnsConnection = false) 
            : base(existingConnection, contextOwnsConnection) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var convention = new AttributeToColumnAnnotationConvention<DefaultValueAttribute, string>("SqlDefaultValue", (p, attributes) => attributes.SingleOrDefault().Value.ToString());
            //modelBuilder.Conventions.Add(convention);

            //modelBuilder.Entity<Phone>().Property(it => it.PhoneInfo).IsOptional();
        }

 
    }

    //public class StoreDbInitializer : DropCreateDatabaseAlways<MobileContext>
    //{
    //    protected override void Seed(MobileContext db)
    //    {
    //        db.Phones.Add(new Phone { Name = "Nokia Lumia 630", Company = "Nokia", Price = 220 });
    //        db.Phones.Add(new Phone { Name = "iPhone 6", Company = "Apple", Price = 320 });
    //        db.Phones.Add(new Phone { Name = "LG G4", Company = "lG", Price = 260 });
    //        db.Phones.Add(new Phone { Name = "Samsung Galaxy S 6", Company = "Samsung", Price = 300 });
       
    //        db.SaveChanges();
    //    }
    //}
}