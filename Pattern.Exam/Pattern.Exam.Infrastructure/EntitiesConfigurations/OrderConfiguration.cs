using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pattern.Exam.Infrastructure.Entities;

namespace Pattern.Exam.Infrastructure.EntitiesConfigurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("Id");
            builder.Property(r => r.TotalCost).HasColumnName("TotalCost");
            builder.Property(r => r.CreateDate).HasColumnName("CreateDate");
            builder.Property(r => r.IsDiscounted).HasColumnName("IsDiscounted");
            builder.Property(r => r.AccountId).HasColumnName("AccountId");

            builder.HasOne(r => r.Account)
                    .WithMany(r => r.Orders)
                    .HasForeignKey(r => r.AccountId);

            builder.HasMany(r => r.Products)
                .WithOne(r => r.Order)
                .HasForeignKey(r => r.OrderId);

        }
    }
}
