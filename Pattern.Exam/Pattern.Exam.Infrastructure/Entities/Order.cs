namespace Pattern.Exam.Infrastructure.Entities
{
    public class Order: BaseEntity
    {
        public Guid AccountId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModified { get; set; }
        public decimal TotalCost { get; set; } = 0;
        public bool IsDiscounted { get; set; }

        public Order()
        {
            Products = new HashSet<Product>();
        }

        public virtual Account Account { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
