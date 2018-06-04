namespace ACS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employees", new[] { "ApplicationUser_Id" });
            RenameColumn(table: "dbo.AspNetUsers", name: "ApplicationUser_Id", newName: "Employee_Id");
            AlterColumn("dbo.Chancelleries", "s_DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Chancelleries", "s_EditDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Chancelleries", "s_IsLocked", c => c.Boolean(nullable: false, defaultValue: false));
            AlterColumn("dbo.Files", "s_DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Files", "s_EditDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Files", "s_IsLocked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FolderChancelleries", "s_DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.FolderChancelleries", "s_EditDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.FolderChancelleries", "s_IsLocked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_EditDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_IsLocked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Employees", "s_DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employees", "s_EditDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employees", "s_IsLocked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TypeRecordChancelleries", "s_DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.TypeRecordChancelleries", "s_EditDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.TypeRecordChancelleries", "s_IsLocked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ExternalOrganizations", "s_DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ExternalOrganizations", "s_EditDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ExternalOrganizations", "s_IsLocked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FromEmplChancelleries", "s_DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.FromEmplChancelleries", "s_EditDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.FromEmplChancelleries", "s_IsLocked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_EditDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_IsLocked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ToEmplChancelleries", "s_DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ToEmplChancelleries", "s_EditDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ToEmplChancelleries", "s_IsLocked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_EditDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_IsLocked", c => c.Boolean(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Employee_Id");
            DropColumn("dbo.Employees", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ApplicationUser_Id", c => c.Int());
            DropIndex("dbo.AspNetUsers", new[] { "Employee_Id" });
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_EditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ToEmplChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.ToEmplChancelleries", "s_EditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ToEmplChancelleries", "s_DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_EditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FromEmplChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.FromEmplChancelleries", "s_EditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FromEmplChancelleries", "s_DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ExternalOrganizations", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.ExternalOrganizations", "s_EditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ExternalOrganizations", "s_DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TypeRecordChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.TypeRecordChancelleries", "s_EditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TypeRecordChancelleries", "s_DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.Employees", "s_EditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "s_DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_EditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FolderChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.FolderChancelleries", "s_EditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FolderChancelleries", "s_DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Files", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.Files", "s_EditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Files", "s_DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Chancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.Chancelleries", "s_EditDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Chancelleries", "s_DateCreation", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.AspNetUsers", name: "Employee_Id", newName: "ApplicationUser_Id");
            CreateIndex("dbo.Employees", "ApplicationUser_Id");
        }
    }
}
