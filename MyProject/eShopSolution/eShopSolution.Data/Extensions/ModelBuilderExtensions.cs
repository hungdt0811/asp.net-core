using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using eShopSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;


namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is Home page of EshopSolution" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is Keyword of EshopSolution" },
                new AppConfig() { Key = "HomeDescription", Value = "This is Description of EshopSolution" }
            );

            modelBuilder.Entity<Language>().HasData(
                    new Language() { Id = "vi-VN", Name = "Tiếng việt", IsDefault = true },
                    new Language() { Id = "en-US", Name = "English", IsDefault = false }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    SortOrder = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 2,
                    SortOrder = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    Status = Status.Active,
                }
            );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new List<CategoryTranslation>() {
                        new CategoryTranslation() {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Áo nam",
                            LanguageId = "vi-VN",
                            SeoAlias = "ao-nam",
                            SeoDescription = "Sản phẩm áo thời trang nam" ,
                            SeoTitle = ""
                        },
                        new CategoryTranslation() {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Men Shirt",
                            LanguageId = "en-US",
                            SeoAlias = "men-shirt",
                            SeoDescription = "The shirt products for men" ,
                            SeoTitle = ""
                        },
                        new CategoryTranslation() {
                            Id = 3,
                            CategoryId = 2,
                            Name = "Áo nữ",
                            LanguageId = "vi-VN",
                            SeoAlias = "ao-nu",
                            SeoDescription = "Sản phẩm áo thời trang nữ" ,
                            SeoTitle = "Sản phẩm áo thời trang nữ"
                        },
                        new CategoryTranslation() {
                            Id = 4,
                            CategoryId = 2,
                            Name = "Woman Shirt",
                            LanguageId = "en-US",
                            SeoAlias = "woman-shirt",
                            SeoDescription = "The shirt products for woman" ,
                            SeoTitle = "The shirt products for woman"
                        }
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 0,
                    ViewCount = 0,
                }
            ); ;

            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id = 1,
                    ProductId = 1,
                    Name = "Áo sơ mi trắng nam AAA",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-so-mi-trang-nam",
                    SeoDescription = "Sản phẩm Áo sơ mi trắng nam",
                    SeoTitle = "Sản phẩm Áo sơ mi trắng nam",
                    Details = "Sản phẩm Áo sơ mi trắng nam",
                    Description = "Sản phẩm Áo sơ mi trắng nam",
                },
                new ProductTranslation()
                {
                    Id = 2,
                    ProductId = 1,
                    Name = "AAA Men T-Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "aaa-men-tshirt",
                    SeoDescription = "The aaa t-shirt products for men",
                    SeoTitle = "The aaa t-shirt products for men",
                    Details = "The aaa t-shirt products for men",
                    Description = "The aaa t-shirt products for men",
                }
            );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
            );

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "hungdt0811@gmail.com",
                NormalizedEmail = "hungdt0811@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abc@123"),
                SecurityStamp = string.Empty,
                FirstName = "Hung",
                LastName = "Dang",
                Dob = new DateTime(1997, 11, 08)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
