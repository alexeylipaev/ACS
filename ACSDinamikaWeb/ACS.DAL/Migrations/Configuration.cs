namespace ACS.DAL.Migrations
{
    using EF;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;
    using XMLData;

    internal sealed class Configuration : DbMigrationsConfiguration<ACSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//�������������� ���������� ��
            AutomaticMigrationDataLossAllowed = true;//��������� �� ���� ���� ��� ���� ����� ������� ������
            // DefaultValue Sql Generator
            SetSqlGenerator("System.Data.SqlClient", new DefaultValueSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(ACSContext db)
        {

            //Debug.WriteLine("GenerateUserRepository");
            //DataLoader1C.GenerateUserRepository(db);
            //Debug.WriteLine("GenerateDepartmentRepository");
            //DataLoader1C.GenerateDepartmentRepository(db);
            //Debug.WriteLine("GeneratePostRepository");
            //DataLoader1C.GeneratePostRepository(db);
            //Debug.WriteLine("GeneratePostUser�ode1�Repository");
            //DataLoader1C.GeneratePostUser�ode1�Repository(db);
            //Debug.WriteLine("GenerateWorkHistoryRepository");
            //DataLoader1C.GenerateWorkHistoryRepository(db);
            //Debug.WriteLine("GenerateTypeAccessRepository");
            //DataLoader1C.GenerateTypeAccessRepository(db);
            //Debug.WriteLine("GenerateTypeRecordChancelleryRepository");
            //DataLoader1C.GenerateTypeRecordChancelleryRepository(db);
        }


    }

}
