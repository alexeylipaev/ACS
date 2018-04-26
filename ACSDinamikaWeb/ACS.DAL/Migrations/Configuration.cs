namespace ACS.DAL.Migrations
{
    using EF;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using XMLData;

    internal sealed class Configuration : DbMigrationsConfiguration<ACSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//автоматическое обновление бд
            AutomaticMigrationDataLossAllowed = true;//обновлять бд даже если при этом будут утеряны данные
            // DefaultValue Sql Generator
            //SetSqlGenerator("System.Data.SqlClient", new DefaultValueSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(ACSContext db)
        {
            //Console.WriteLine("GenerateUserRepository");
            //DataLoader1C.GenerateUserRepository(db);
            //Console.WriteLine("GenerateDepartmentRepository");
            //DataLoader1C.GenerateDepartmentRepository(db);
            //Console.WriteLine("GeneratePostRepository");
            //DataLoader1C.GeneratePostRepository(db);
            //Console.WriteLine("GeneratePostUserСode1СRepository");
            //DataLoader1C.GeneratePostUserСode1СRepository(db);
            //Console.WriteLine("GenerateWorkHistoryRepository");
            //DataLoader1C.GenerateWorkHistoryRepository(db);
            //Console.WriteLine("GenerateTypeAccessRepository");
            //DataLoader1C.GenerateTypeAccessRepository(db);
            //Console.WriteLine("GenerateTypeRecordChancelleryRepository");
            //DataLoader1C.GenerateTypeRecordChancelleryRepository(db);
        }


    }

}
