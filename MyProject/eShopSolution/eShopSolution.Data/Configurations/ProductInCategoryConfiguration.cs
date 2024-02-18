using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories");
            builder.HasKey(pic => new {pic.ProductId, pic.CategoryId});

            builder.HasOne(x => x.Product)
                .WithMany(p => p.ProductInCategories)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Category)
                .WithMany(c =>  c.ProductInCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
