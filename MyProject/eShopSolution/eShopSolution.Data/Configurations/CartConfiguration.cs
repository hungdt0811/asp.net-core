using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace eShopSolution.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(x => x.Id);

            builder.HasOne(c => c.Product).WithMany(u => u.Carts).HasForeignKey(c => c.ProductId);
            builder.HasOne(c => c.User).WithMany(u => u.Carts).HasForeignKey(c => c.UserId);
        }
    }
}
