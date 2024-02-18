using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ShipEmail)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false); // Khai báo trường này là Varchar chứ không phải nVarchar

            builder.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);

        }
    }
}
