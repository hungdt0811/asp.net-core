using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace eShopSolution.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Dob).IsRequired();
        }
    }
}
