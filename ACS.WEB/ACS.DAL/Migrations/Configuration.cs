using ACS.DAL.EF;
using System.Data.Entity.Migrations;
using System.Diagnostics;

namespace ACS.DAL.Migrations
{

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
            Debug.WriteLine("GenerateAppRolesRepository");
            DataLoader1C.GenerateAppRolesRepository(db);
            Debug.WriteLine("GenerateApplicationUserSystem");
            DataLoader1C.GenerateApplicationUserSystem(db);
            Debug.WriteLine("GenerateUserRepository");
            DataLoader1C.GenerateUserRepository(db);
            Debug.WriteLine("GenerateDepartmentRepository");
            DataLoader1C.GenerateDepartmentRepository(db);
            Debug.WriteLine("GeneratePostRepository");
            DataLoader1C.GeneratePostRepository(db);
            Debug.WriteLine("GeneratePostsEmployeesСode1СRepository");
            DataLoader1C.GeneratePostsEmployeesСode1СRepository(db);
            Debug.WriteLine("GenerateWorkHistoryRepository");
            DataLoader1C.GenerateWorkHistoryRepository(db);
            Debug.WriteLine("GenerateTypeAccessRepository");
            DataLoader1C.GenerateTypeAccessRepository(db);
            Debug.WriteLine("GenerateTypeRecordChancelleryRepository");
            DataLoader1C.GenerateTypeRecordChancelleryRepository(db);
        }


    }

}
