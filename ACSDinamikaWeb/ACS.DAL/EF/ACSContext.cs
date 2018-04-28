using ACS.DAL.Configuration;
using ACS.DAL.Entities;

using ACS.XMLData;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.DAL.EF
{

    //public class ACSContext : DbContext
    public class ACSContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Access> Accesses { get; set; }

        public virtual DbSet<ApplicationUser> ApplicationUserRepository { get; set; }
        public virtual DbSet<ApplicationClaim> ApplicationClaims { get; set; }
        public virtual DbSet<ApplicationLogin> ApplicationLogins { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRoleRepository { get; set; }
        public virtual DbSet<Chancellery> Chancelleries { get; set; }
        public virtual DbSet<DataEntity> DataEntityis { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<ExternalOrganizationChancellery> ExternalOrganizationChancelleries { get; set; }
        public virtual DbSet<FileRecordChancellery> FileRecordChancelleries { get; set; }
        public virtual DbSet<FolderChancellery> FolderChancelleries { get; set; }
        public virtual DbSet<FromChancellery> FromChancelleries { get; set; }
        public virtual DbSet<JournalRegistrationsChancellery> JournalRegistrationsChancelleries { get; set; }
        public virtual DbSet<PostNameEmployee> PostsEmployees { get; set; }
        public virtual DbSet<PostsEmployeesСode1С> PostsEmployeesСode1С { get; set; }
        public virtual DbSet<ToChancellery> ToChancelleries { get; set; }
        public virtual DbSet<TypeAccess> TypeAccesses { get; set; }
        public virtual DbSet<TypeRecordChancellery> TypeRecordChancelleries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        
        public virtual DbSet<WorkHistory> WorkHistories { get; set; }
        public virtual DbSet<EmployeePassport> EmployeesPassports { get; set; }




        //ACSContextConnection
        //DefaultConnection
        public ACSContext(string connectionString = "ACSContextConnection")
            : base(connectionString)
        {
            Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<ACSContext, ACS.DAL.Migrations.Configuration>());
            //Database.SetInitializer<ACSContext>(new StoreDbInitializer());
        }  

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Configurations.Add(new AccessConfig());
            modelBuilder.Configurations.Add(new ApplicationClaimConfig());
            modelBuilder.Configurations.Add(new ApplicationUserConfig());
            modelBuilder.Configurations.Add(new ApplicationLoginConfig());
            modelBuilder.Configurations.Add(new ApplicationRoleConfig());
            modelBuilder.Configurations.Add(new ChancelleryConfig());
            modelBuilder.Configurations.Add(new DataEntityConfig());
            modelBuilder.Configurations.Add(new DepartmentConfig());
            modelBuilder.Configurations.Add(new ExternalOrganizationChancelleryConfig());
            modelBuilder.Configurations.Add(new FileRecordChancelleryConfig());
            modelBuilder.Configurations.Add(new FolderChancelleryConfig());
            modelBuilder.Configurations.Add(new JournalRegistrationsChancelleryConfig());
            modelBuilder.Configurations.Add(new PostNameUserConfig());
            modelBuilder.Configurations.Add(new TypeAccessConfig());
            modelBuilder.Configurations.Add(new TypeRecordChancelleryConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new UserPassportConfig());


            var convention = new AttributeToColumnAnnotationConvention<DefaultValueAttribute, string>("SqlDefaultValue", (p, attributes) => attributes.SingleOrDefault().Value.ToString());
            modelBuilder.Conventions.Add(convention);
        }

    }

    //    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ACSContext>
    //    {
    //        protected override void Seed(ACSContext db)
    //        {
    //Console.WriteLine("GenerateUserRepository");
    //DataLoader1C.GenerateUserRepository(db);
    //Console.WriteLine("GenerateDepartmentRepository");
    //DataLoader1C.GenerateDepartmentRepository(db);
    //Console.WriteLine("GeneratePostRepository");
    //DataLoader1C.GeneratePostRepository(db);
    //Console.WriteLine("GeneratePostsEmployeesСode1СRepository");
    //DataLoader1C.GeneratePostsEmployeesСode1СRepository(db);
    //Console.WriteLine("GenerateWorkHistoryRepository");
    //DataLoader1C.GenerateWorkHistoryRepository(db);
    //Console.WriteLine("GenerateTypeAccessRepository");
    //DataLoader1C.GenerateTypeAccessRepository(db);
    //Console.WriteLine("GenerateTypeRecordChancelleryRepository");
    //DataLoader1C.GenerateTypeRecordChancelleryRepository(db);
    //}}

}


