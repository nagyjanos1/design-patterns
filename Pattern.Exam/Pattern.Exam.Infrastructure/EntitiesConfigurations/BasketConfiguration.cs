using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pattern.Exam.Infrastructure.Entities;

namespace Pattern.Exam.Infrastructure.EntitiesConfigurations
{
    internal class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Basket");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("Id");
            builder.Property(r => r.AccountId).HasColumnName("AccountId");

            builder.HasMany(r => r.Products)
                    .WithOne(r => r.Basket)
                    .HasForeignKey(r => r.BasketId);

        }
    }
}
