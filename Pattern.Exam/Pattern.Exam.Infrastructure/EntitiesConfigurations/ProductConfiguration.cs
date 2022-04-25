using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pattern.Exam.Infrastructure.Entities;

namespace Pattern.Exam.Infrastructure.EntitiesConfigurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("Id");
            builder.Property(r => r.Price).HasColumnName("Price");
            builder.Property(r => r.Name).HasColumnName("Name");

            builder.HasOne(r => r.Order)
                    .WithMany(r => r.Products)
                    .HasForeignKey(r => r.OrderId);

            builder.HasOne(r => r.Basket)
                    .WithMany(r => r.Products)
                    .HasForeignKey(r => r.BasketId);

        }
    }
}
