using eShopSolution.Data.Entities;
using eShopSolution.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace eShopSolution.Data.EF
{
    public class EShopDbContext : IdentityDbContext<User,Role,Guid>
    {
        private string ConnectString = @"
            Data Source = DESKTOP-HS1TEUQ;
            Initial Catalog = eShopDB;
            UID=sa;
            PWD=123;
            trusted_connection=true;
        ";
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductTranslation> ProductTranslations { get; set; } = null!;
        public DbSet<ProductInCategory> ProductInCategories { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<AppConfig> AppConfigs { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Language> Languages { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<ProductImage> ProductImages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectString);  // khai báo sử dụng SQL server với connect string
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add config cho 1 Config 
            //modelBuilder.ApplyConfiguration(new AppConfigConfiguration());

            // Add tất cả config implement từ interface IentityTypeConfiguration 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");


            // Data Seeding
            modelBuilder.Seed();
        }
        
    }
}
