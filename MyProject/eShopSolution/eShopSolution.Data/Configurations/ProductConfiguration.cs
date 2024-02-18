using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eShopSolution.Data.Entities;

namespace eShopSolution.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);  // PK

            builder.Property(p => p.SeoAlias).IsRequired(); // not null
            builder.Property(p => p.Stock)
                .IsRequired()               // not null
                .HasDefaultValue<int>(0);   // default value

            builder.Property(p => p.ViewCount)
                .IsRequired()               // not null
                .HasDefaultValue<int>(0);   // default value

            builder.Property(p => p.OriginalPrice)
                .IsRequired();              // not null

        }
    }
}
