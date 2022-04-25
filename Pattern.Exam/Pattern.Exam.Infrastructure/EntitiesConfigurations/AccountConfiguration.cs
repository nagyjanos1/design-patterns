using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pattern.Exam.Infrastructure.Entities;

namespace Pattern.Exam.Infrastructure.EntitiesConfigurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("Id");
            builder.Property(r => r.Number).HasColumnName("Number");
            builder.Property(r => r.CreateDate).HasColumnName("CreateDate");

            builder.HasMany(r => r.Orders)
                    .WithOne(r => r.Account)
                    .HasForeignKey(r => r.AccountId);
        }
    }
}
