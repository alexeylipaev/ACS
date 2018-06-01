namespace ACS.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chancelleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationNumber = c.String(),
                        DateRegistration = c.DateTime(),
                        Summary = c.String(),
                        Notice = c.String(),
                        Status = c.String(),
                        TypeRecordChancelleryId = c.Int(nullable: false),
                        FolderChancelleryId = c.Int(),
                        JournalRegistrationsChancelleryId = c.Int(),
                        s_Guid = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "newsequentialid()")
                                },
                            }),
                        s_AuthorId = c.Int(nullable: false),
                        s_DateCreation = c.DateTime(nullable: false),
                        s_EditorId = c.Int(nullable: false),
                        s_EditDate = c.DateTime(nullable: false),
                        s_IsLocked = c.Boolean(),
                        s_LockedBy_Id = c.Int(),
                        s_InBasket = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FolderChancelleries", t => t.FolderChancelleryId)
                .ForeignKey("dbo.JournalRegistrationsChancelleries", t => t.JournalRegistrationsChancelleryId)
                .ForeignKey("dbo.TypeRecordChancelleries", t => t.TypeRecordChancelleryId)
                .Index(t => t.TypeRecordChancelleryId)
                .Index(t => t.FolderChancelleryId)
                .Index(t => t.JournalRegistrationsChancelleryId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Extension = c.String(),
                        Path = c.String(nullable: false),
                        DataString = c.String(),
                        s_Guid = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "newsequentialid()")
                                },
                            }),
                        s_AuthorId = c.Int(nullable: false),
                        s_DateCreation = c.DateTime(nullable: false),
                        s_EditorId = c.Int(nullable: false),
                        s_EditDate = c.DateTime(nullable: false),
                        s_IsLocked = c.Boolean(),
                        s_LockedBy_Id = c.Int(),
                        s_InBasket = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FolderChancelleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        s_Guid = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "newsequentialid()")
                                },
                            }),
                        s_AuthorId = c.Int(nullable: false),
                        s_DateCreation = c.DateTime(nullable: false),
                        s_EditorId = c.Int(nullable: false),
                        s_EditDate = c.DateTime(nullable: false),
                        s_IsLocked = c.Boolean(),
                        s_LockedBy_Id = c.Int(),
                        s_InBasket = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.JournalRegistrationsChancelleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        s_Guid = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "newsequentialid()")
                                },
                            }),
                        s_AuthorId = c.Int(nullable: false),
                        s_DateCreation = c.DateTime(nullable: false),
                        s_EditorId = c.Int(nullable: false),
                        s_EditDate = c.DateTime(nullable: false),
                        s_IsLocked = c.Boolean(),
                        s_LockedBy_Id = c.Int(),
                        s_InBasket = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        MName = c.String(),
                        Email = c.String(),
                        Guid1C = c.Guid(),
                        ApplicationUserId = c.Int(),
                        s_Guid = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "newsequentialid()")
                                },
                            }),
                        s_AuthorId = c.Int(nullable: false),
                        s_DateCreation = c.DateTime(nullable: false),
                        s_EditorId = c.Int(nullable: false),
                        s_EditDate = c.DateTime(nullable: false),
                        s_IsLocked = c.Boolean(),
                        s_LockedBy_Id = c.Int(),
                        s_InBasket = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TypeRecordChancelleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        s_Guid = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "newsequentialid()")
                                },
                            }),
                        s_AuthorId = c.Int(nullable: false),
                        s_DateCreation = c.DateTime(nullable: false),
                        s_EditorId = c.Int(nullable: false),
                        s_EditDate = c.DateTime(nullable: false),
                        s_IsLocked = c.Boolean(),
                        s_LockedBy_Id = c.Int(),
                        s_InBasket = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.ExternalOrganizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        s_Guid = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "newsequentialid()")
                                },
                            }),
                        s_AuthorId = c.Int(nullable: false),
                        s_DateCreation = c.DateTime(nullable: false),
                        s_EditorId = c.Int(nullable: false),
                        s_EditDate = c.DateTime(nullable: false),
                        s_IsLocked = c.Boolean(),
                        s_LockedBy_Id = c.Int(),
                        s_InBasket = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.FromEmplChancelleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(),
                        ChancelleryId = c.Int(nullable: false),
                        s_Guid = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "newsequentialid()")
                                },
                            }),
                        s_AuthorId = c.Int(nullable: false),
                        s_DateCreation = c.DateTime(nullable: false),
                        s_EditorId = c.Int(nullable: false),
                        s_EditDate = c.DateTime(nullable: false),
                        s_IsLocked = c.Boolean(),
                        s_LockedBy_Id = c.Int(),
                        s_InBasket = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chancelleries", t => t.ChancelleryId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ChancelleryId);
            
            CreateTable(
                "dbo.FromExtlOrgChancelleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalOrganizationId = c.Int(),
                        ChancelleryId = c.Int(nullable: false),
                        s_Guid = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "newsequentialid()")
                                },
                            }),
                        s_AuthorId = c.Int(nullable: false),
                        s_DateCreation = c.DateTime(nullable: false),
                        s_EditorId = c.Int(nullable: false),
                        s_EditDate = c.DateTime(nullable: false),
                        s_IsLocked = c.Boolean(),
                        s_LockedBy_Id = c.Int(),
                        s_InBasket = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chancelleries", t => t.ChancelleryId, cascadeDelete: true)
                .ForeignKey("dbo.ExternalOrganizations", t => t.ExternalOrganizationId)
                .Index(t => t.ExternalOrganizationId)
                .Index(t => t.ChancelleryId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ToEmplChancelleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(),
                        ChancelleryId = c.Int(nullable: false),
                        s_Guid = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "newsequentialid()")
                                },
                            }),
                        s_AuthorId = c.Int(nullable: false),
                        s_DateCreation = c.DateTime(nullable: false),
                        s_EditorId = c.Int(nullable: false),
                        s_EditDate = c.DateTime(nullable: false),
                        s_IsLocked = c.Boolean(),
                        s_LockedBy_Id = c.Int(),
                        s_InBasket = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chancelleries", t => t.ChancelleryId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ChancelleryId);
            
            CreateTable(
                "dbo.ToExtlOrgChancelleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExternalOrganizationId = c.Int(),
                        ChancelleryId = c.Int(nullable: false),
                        s_Guid = c.Guid(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "newsequentialid()")
                                },
                            }),
                        s_AuthorId = c.Int(nullable: false),
                        s_DateCreation = c.DateTime(nullable: false),
                        s_EditorId = c.Int(nullable: false),
                        s_EditDate = c.DateTime(nullable: false),
                        s_IsLocked = c.Boolean(),
                        s_LockedBy_Id = c.Int(),
                        s_InBasket = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chancelleries", t => t.ChancelleryId, cascadeDelete: true)
                .ForeignKey("dbo.ExternalOrganizations", t => t.ExternalOrganizationId)
                .Index(t => t.ExternalOrganizationId)
                .Index(t => t.ChancelleryId);
            
            CreateTable(
                "dbo.ChancelleryFiles",
                c => new
                    {
                        Chancellery_Id = c.Int(nullable: false),
                        Files_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Chancellery_Id, t.Files_Id })
                .ForeignKey("dbo.Chancelleries", t => t.Chancellery_Id, cascadeDelete: true)
                .ForeignKey("dbo.Files", t => t.Files_Id, cascadeDelete: true)
                .Index(t => t.Chancellery_Id)
                .Index(t => t.Files_Id);
            
            CreateTable(
                "dbo.ChancelleryEmployees",
                c => new
                    {
                        Chancellery_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Chancellery_Id, t.Employee_Id })
                .ForeignKey("dbo.Chancelleries", t => t.Chancellery_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Chancellery_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToExtlOrgChancelleries", "ExternalOrganizationId", "dbo.ExternalOrganizations");
            DropForeignKey("dbo.ToExtlOrgChancelleries", "ChancelleryId", "dbo.Chancelleries");
            DropForeignKey("dbo.ToEmplChancelleries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ToEmplChancelleries", "ChancelleryId", "dbo.Chancelleries");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FromExtlOrgChancelleries", "ExternalOrganizationId", "dbo.ExternalOrganizations");
            DropForeignKey("dbo.FromExtlOrgChancelleries", "ChancelleryId", "dbo.Chancelleries");
            DropForeignKey("dbo.FromEmplChancelleries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.FromEmplChancelleries", "ChancelleryId", "dbo.Chancelleries");
            DropForeignKey("dbo.Chancelleries", "TypeRecordChancelleryId", "dbo.TypeRecordChancelleries");
            DropForeignKey("dbo.ChancelleryEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.ChancelleryEmployees", "Chancellery_Id", "dbo.Chancelleries");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chancelleries", "JournalRegistrationsChancelleryId", "dbo.JournalRegistrationsChancelleries");
            DropForeignKey("dbo.Chancelleries", "FolderChancelleryId", "dbo.FolderChancelleries");
            DropForeignKey("dbo.ChancelleryFiles", "Files_Id", "dbo.Files");
            DropForeignKey("dbo.ChancelleryFiles", "Chancellery_Id", "dbo.Chancelleries");
            DropIndex("dbo.ChancelleryEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.ChancelleryEmployees", new[] { "Chancellery_Id" });
            DropIndex("dbo.ChancelleryFiles", new[] { "Files_Id" });
            DropIndex("dbo.ChancelleryFiles", new[] { "Chancellery_Id" });
            DropIndex("dbo.ToExtlOrgChancelleries", new[] { "ChancelleryId" });
            DropIndex("dbo.ToExtlOrgChancelleries", new[] { "ExternalOrganizationId" });
            DropIndex("dbo.ToEmplChancelleries", new[] { "ChancelleryId" });
            DropIndex("dbo.ToEmplChancelleries", new[] { "EmployeeId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FromExtlOrgChancelleries", new[] { "ChancelleryId" });
            DropIndex("dbo.FromExtlOrgChancelleries", new[] { "ExternalOrganizationId" });
            DropIndex("dbo.FromEmplChancelleries", new[] { "ChancelleryId" });
            DropIndex("dbo.FromEmplChancelleries", new[] { "EmployeeId" });
            DropIndex("dbo.ExternalOrganizations", new[] { "Name" });
            DropIndex("dbo.TypeRecordChancelleries", new[] { "Name" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Employees", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.JournalRegistrationsChancelleries", new[] { "Name" });
            DropIndex("dbo.FolderChancelleries", new[] { "Name" });
            DropIndex("dbo.Chancelleries", new[] { "JournalRegistrationsChancelleryId" });
            DropIndex("dbo.Chancelleries", new[] { "FolderChancelleryId" });
            DropIndex("dbo.Chancelleries", new[] { "TypeRecordChancelleryId" });
            DropTable("dbo.ChancelleryEmployees");
            DropTable("dbo.ChancelleryFiles");
            DropTable("dbo.ToExtlOrgChancelleries",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "s_Guid",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "newsequentialid()" },
                        }
                    },
                });
            DropTable("dbo.ToEmplChancelleries",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "s_Guid",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "newsequentialid()" },
                        }
                    },
                });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FromExtlOrgChancelleries",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "s_Guid",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "newsequentialid()" },
                        }
                    },
                });
            DropTable("dbo.FromEmplChancelleries",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "s_Guid",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "newsequentialid()" },
                        }
                    },
                });
            DropTable("dbo.ExternalOrganizations",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "s_Guid",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "newsequentialid()" },
                        }
                    },
                });
            DropTable("dbo.TypeRecordChancelleries",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "s_Guid",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "newsequentialid()" },
                        }
                    },
                });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Employees",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "s_Guid",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "newsequentialid()" },
                        }
                    },
                });
            DropTable("dbo.JournalRegistrationsChancelleries",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "s_Guid",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "newsequentialid()" },
                        }
                    },
                });
            DropTable("dbo.FolderChancelleries",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "s_Guid",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "newsequentialid()" },
                        }
                    },
                });
            DropTable("dbo.Files",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "s_Guid",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "newsequentialid()" },
                        }
                    },
                });
            DropTable("dbo.Chancelleries",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "s_Guid",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "newsequentialid()" },
                        }
                    },
                });
        }
    }
}
