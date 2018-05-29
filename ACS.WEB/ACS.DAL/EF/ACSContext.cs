using ACS.DAL.Config;
using ACS.DAL.Entities;
using ACS.DAL.Migrations;
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
    public class ACSContext : IdentityDbContext<ApplicationUser, ApplicationRole,
    int, AppUserLogin, AppUserRole, AppUserClaim>
    {

        public ACSContext(string connectionString)
            : base(connectionString) {
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
         
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ExternalOrganization> ExternalOrganization { get; set; }
        public virtual DbSet<Files> Files { get; set; }

        #region Chancellery
        public virtual DbSet<Chancellery> Chancelleries { get; set; }
        public virtual DbSet<FolderChancellery> FolderChancelleries { get; set; }
        public virtual DbSet<JournalRegistrationsChancellery> JournalRegistrationsChancelleries { get; set; }
        public virtual DbSet<TypeRecordChancellery> TypeRecordChancelleries { get; set; }

        #region To
        public virtual DbSet<ToEmplChancellery> ToEmplsChancellery { get; set; }
        public virtual DbSet<ToExtlOrgChancellery> ToExtlOrgsChancellery { get; set; }
        #endregion

        #region From
        public virtual DbSet<FromEmplChancellery> FromEmplsChancellery { get; set; }
        public virtual DbSet<FromExtlOrgChancellery> FromExtlOrgsChancellery { get; set; }
        #endregion

        #endregion

        static ACSContext()
        {
            Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<ACSContext, ACS.DAL.Migrations.Configuration>());
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            //modelBuilder.Configurations.Add(new EntityConfig());

            modelBuilder.Configurations.Add(new AppUserRoleConfig());
            modelBuilder.Configurations.Add(new ApplicationUserConfig());
            modelBuilder.Configurations.Add(new ApplicationRoleConfig());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ChancelleryConfig());
            modelBuilder.Configurations.Add(new FilesConfig());
            modelBuilder.Configurations.Add(new JournalRegistrationsChancelleryConfig());
            modelBuilder.Configurations.Add(new FolderChancelleryConfig());
            modelBuilder.Configurations.Add(new TypeRecordChancelleryConfig());
            modelBuilder.Configurations.Add(new ExternalOrganizationConfig());
            //modelBuilder.Configurations.Add(new TypeAccessConfig());

            var convention = new AttributeToColumnAnnotationConvention<DefaultValueAttribute, string>("SqlDefaultValue", (p, attributes) => attributes.SingleOrDefault().Value.ToString());
            modelBuilder.Conventions.Add(convention);

            //modelBuilder.Configurations.Add(new TypeRecordChancelleryConfig());


            //modelBuilder.Configurations.Add(new ExternalOrganizationChancelleryConfig());
            //modelBuilder.Configurations.Add(new FileRecordChancelleryConfig());
            //modelBuilder.Configurations.Add(new FolderChancelleryConfig());
            //modelBuilder.Configurations.Add(new JournalRegistrationsChancelleryConfig());

            //modelBuilder.Configurations.Add(new DepartmentConfig());
            //modelBuilder.Configurations.Add(new EmployeeConfig());
            //modelBuilder.Configurations.Add(new EmployeePassportConfig());
            //modelBuilder.Configurations.Add(new PostEmployeeСode1СConfig());
            //modelBuilder.Configurations.Add(new PostNameEmployeeConfig());
            //modelBuilder.Configurations.Add(new WorkHistoryConfig());

            //modelBuilder.Configurations.Add(new DataEntityConfig());
            //modelBuilder.Configurations.Add(new ProjectRegistryConfig());


        }
        Configuration Config = null;
        public void RunSeed()
        {
            if (Config == null)
                Config = new Configuration();
            Config.PublicSeed(this);
        }

    }
}




