using Microsoft.EntityFrameworkCore;
using Pattern.Exam.Infrastructure.Entities;

namespace Pattern.Exam.Infrastructure
{
    public class WebShopDbContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }


        public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebShopDbContext).Assembly);
        }
    }
}
