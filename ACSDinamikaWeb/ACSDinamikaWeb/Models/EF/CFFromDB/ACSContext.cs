namespace ACSWeb.Models.EF.CFFromDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ACSContext : DbContext
    {
        public ACSContext()
            : base("name=ACSContextConnection")
        {
        }

        public virtual DbSet<Access> Accesses { get; set; }
        public virtual DbSet<ASPClaimsIdentityUser> ASPClaimsIdentityUsers { get; set; }
        public virtual DbSet<ASPIdentityUser> ASPIdentityUsers { get; set; }
        public virtual DbSet<ASPLoginsIdentityUser> ASPLoginsIdentityUsers { get; set; }
        public virtual DbSet<ASPRolesIdentityUser> ASPRolesIdentityUsers { get; set; }
        public virtual DbSet<Chancellery> Chancelleries { get; set; }
        public virtual DbSet<DataTable> DataTables { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<ExternalOrganizationChancellery> ExternalOrganizationChancelleries { get; set; }
        public virtual DbSet<FileRecordChancellery> FileRecordChancelleries { get; set; }
        public virtual DbSet<FolderChancellery> FolderChancelleries { get; set; }
        public virtual DbSet<FromChancellery> FromChancelleries { get; set; }
        public virtual DbSet<JournalRegistrationsChancellery> JournalRegistrationsChancelleries { get; set; }
        public virtual DbSet<PostUser> PostUsers { get; set; }
        public virtual DbSet<PostUserСode1С> PostUserСode1С { get; set; }
        public virtual DbSet<ToChancellery> ToChancelleries { get; set; }
        public virtual DbSet<TypeAccess> TypeAccesses { get; set; }
        public virtual DbSet<TypeRecordChancellery> TypeRecordChancelleries { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkHistory> WorkHistories { get; set; }
        public virtual DbSet<PassportDataUser> PassportDataUsers { get; set; }
        public virtual DbSet<UsersWithoutWindowsAccount> UsersWithoutWindowsAccounts { get; set; }
        public virtual DbSet<UsersWithWindowsAccount> UsersWithWindowsAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access>()
                .Property(e => e.Note)
                .IsUnicode(true);

            modelBuilder.Entity<ASPClaimsIdentityUser>()
                .Property(e => e.ClaimsId)
                .IsUnicode(true);

            modelBuilder.Entity<ASPClaimsIdentityUser>()
                .Property(e => e.IdentityUserId)
                .IsUnicode(true);

            modelBuilder.Entity<ASPClaimsIdentityUser>()
                .Property(e => e.ClaimType)
                .IsUnicode(true);

            modelBuilder.Entity<ASPClaimsIdentityUser>()
                .Property(e => e.ClaimValue)
                .IsUnicode(true);

            modelBuilder.Entity<ASPIdentityUser>()
                .Property(e => e.IdentityUserId)
                .IsUnicode(true);

            modelBuilder.Entity<ASPIdentityUser>()
                .Property(e => e.IdentityUserName)
                .IsUnicode(true);

            modelBuilder.Entity<ASPIdentityUser>()
                .Property(e => e.PasswordHash)
                .IsUnicode(true);

            modelBuilder.Entity<ASPIdentityUser>()
                .Property(e => e.SecurityStamp)
                .IsUnicode(true);

            modelBuilder.Entity<ASPIdentityUser>()
                .Property(e => e.EMail)
                .IsUnicode(true);

            modelBuilder.Entity<ASPLoginsIdentityUser>()
                .Property(e => e.IdentityUserId)
                .IsUnicode(true);

            modelBuilder.Entity<ASPLoginsIdentityUser>()
                .Property(e => e.ProviderKey)
                .IsUnicode(true);

            modelBuilder.Entity<ASPLoginsIdentityUser>()
                .Property(e => e.LoginProvider)
                .IsUnicode(true);

            modelBuilder.Entity<ASPRolesIdentityUser>()
                .Property(e => e.RoleId)
                .IsUnicode(true);

            modelBuilder.Entity<ASPRolesIdentityUser>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<ASPRolesIdentityUser>()
                .Property(e => e.IdentityUserId)
                .IsUnicode(true);

            modelBuilder.Entity<Chancellery>()
                .Property(e => e.Summary)
                .IsUnicode(true);

            modelBuilder.Entity<Chancellery>()
                .Property(e => e.RegistrationNumber)
                .IsUnicode(true);

            modelBuilder.Entity<Chancellery>()
                .HasMany(e => e.FileRecordChancelleries)
                .WithOptional(e => e.Chancellery)
                .HasForeignKey(e => e.RecordChancelleryId);

            modelBuilder.Entity<Chancellery>()
                .HasMany(e => e.FromChancelleries)
                .WithOptional(e => e.Chancellery)
                .HasForeignKey(e => e.RecordChancelleryId);

            modelBuilder.Entity<Chancellery>()
                .HasMany(e => e.ToChancelleries)
                .WithOptional(e => e.Chancellery)
                .HasForeignKey(e => e.RecordChancelleryId);

            modelBuilder.Entity<DataTable>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Department1)
                .WithOptional(e => e.Department2)
                .HasForeignKey(e => e.ParentDepartmentId);

            modelBuilder.Entity<ExternalOrganizationChancellery>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<ExternalOrganizationChancellery>()
                .Property(e => e.Address)
                .IsUnicode(true);

            modelBuilder.Entity<ExternalOrganizationChancellery>()
                .Property(e => e.City)
                .IsUnicode(true);

            modelBuilder.Entity<ExternalOrganizationChancellery>()
                .Property(e => e.Email)
                .IsUnicode(true);

            modelBuilder.Entity<ExternalOrganizationChancellery>()
                .Property(e => e.Phone)
                .IsUnicode(true);

            modelBuilder.Entity<FileRecordChancellery>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<FileRecordChancellery>()
                .Property(e => e.format)
                .IsUnicode(true);

            modelBuilder.Entity<FileRecordChancellery>()
                .Property(e => e.Path)
                .IsUnicode(true);

            modelBuilder.Entity<FolderChancellery>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<FolderChancellery>()
                .HasMany(e => e.Chancelleries)
                .WithOptional(e => e.FolderChancellery)
                .HasForeignKey(e => e.FolderId);

            modelBuilder.Entity<JournalRegistrationsChancellery>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<JournalRegistrationsChancellery>()
                .HasMany(e => e.Chancelleries)
                .WithOptional(e => e.JournalRegistrationsChancellery)
                .HasForeignKey(e => e.JournalRegistrationsId);

            modelBuilder.Entity<PostUser>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<TypeAccess>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<TypeAccess>()
                .HasMany(e => e.Accesses)
                .WithOptional(e => e.TypeAccess)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TypeRecordChancellery>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<TypeRecordChancellery>()
                .HasMany(e => e.Chancelleries)
                .WithOptional(e => e.TypeRecordChancellery)
                .HasForeignKey(e => e.TypeRecordId);

            modelBuilder.Entity<User>()
                .Property(e => e.FName)
                .IsUnicode(true);

            modelBuilder.Entity<User>()
                .Property(e => e.LName)
                .IsUnicode(true);

            modelBuilder.Entity<User>()
                .Property(e => e.MName)
                .IsUnicode(true);

            modelBuilder.Entity<User>()
                .Property(e => e.PassportSeries)
                .IsUnicode(true);

            modelBuilder.Entity<User>()
                .Property(e => e.PassportNumber)
                .IsUnicode(true);

            modelBuilder.Entity<User>()
                .Property(e => e.PassportIssuedBy)
                .IsUnicode(true);

            modelBuilder.Entity<User>()
                .Property(e => e.PassportUnitCode)
                .IsUnicode(true);

            modelBuilder.Entity<User>()
                .Property(e => e.SID)
                .IsUnicode(true);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Accesses)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Chancelleries)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ResponsibleUserId);

            modelBuilder.Entity<PassportDataUser>()
                .Property(e => e.LName)
                .IsUnicode(true);

            modelBuilder.Entity<PassportDataUser>()
                .Property(e => e.FName)
                .IsUnicode(true);

            modelBuilder.Entity<PassportDataUser>()
                .Property(e => e.MName)
                .IsUnicode(true);

            modelBuilder.Entity<PassportDataUser>()
                .Property(e => e.PassportSeries)
                .IsUnicode(true);

            modelBuilder.Entity<PassportDataUser>()
                .Property(e => e.PassportNumber)
                .IsUnicode(true);

            modelBuilder.Entity<PassportDataUser>()
                .Property(e => e.PassportIssuedBy)
                .IsUnicode(true);

            modelBuilder.Entity<PassportDataUser>()
                .Property(e => e.PassportUnitCode)
                .IsUnicode(true);

            modelBuilder.Entity<UsersWithoutWindowsAccount>()
                .Property(e => e.LName)
                .IsUnicode(true);

            modelBuilder.Entity<UsersWithoutWindowsAccount>()
                .Property(e => e.FName)
                .IsUnicode(true);

            modelBuilder.Entity<UsersWithoutWindowsAccount>()
                .Property(e => e.MName)
                .IsUnicode(true);

            modelBuilder.Entity<UsersWithWindowsAccount>()
                .Property(e => e.LName)
                .IsUnicode(true);

            modelBuilder.Entity<UsersWithWindowsAccount>()
                .Property(e => e.FName)
                .IsUnicode(true);

            modelBuilder.Entity<UsersWithWindowsAccount>()
                .Property(e => e.MName)
                .IsUnicode(true);

            modelBuilder.Entity<UsersWithWindowsAccount>()
                .Property(e => e.SID)
                .IsUnicode(true);
        }
    }
}
