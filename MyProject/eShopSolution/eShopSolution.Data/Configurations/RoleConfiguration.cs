using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShopSolution.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();

        }
    }
}
