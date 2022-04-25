namespace Pattern.Exam.Infrastructure.Entities
{
    public class Basket : BaseEntity
    {
        public Guid AccountId { get; set; }

        public Basket()
        {
            Products = new HashSet<Product>();
        }

        public virtual Account Account { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
