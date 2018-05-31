namespace ACS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Chancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.Chancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Files", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Files", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.Files", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FolderChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.FolderChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.FolderChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Employees", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.Employees", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TypeRecordChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.TypeRecordChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.TypeRecordChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ExternalOrganizations", "s_AuthorId", c => c.Int(nullable: false, defaultValue: 1));
            AlterColumn("dbo.ExternalOrganizations", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.ExternalOrganizations", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FromEmplChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.FromEmplChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.FromEmplChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ToEmplChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.ToEmplChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.ToEmplChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.ToExtlOrgChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.ToEmplChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ToEmplChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.ToEmplChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.FromExtlOrgChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.FromEmplChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FromEmplChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.FromEmplChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.ExternalOrganizations", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ExternalOrganizations", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.ExternalOrganizations", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.TypeRecordChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TypeRecordChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.TypeRecordChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Employees", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.Employees", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.JournalRegistrationsChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.FolderChancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FolderChancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.FolderChancelleries", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Files", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Files", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.Files", "s_AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Chancelleries", "s_InBasket", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Chancelleries", "s_IsLocked", c => c.Boolean());
            AlterColumn("dbo.Chancelleries", "s_AuthorId", c => c.Int(nullable: false));
        }
    }
}
