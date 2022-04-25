namespace Pattern.Exam.Infrastructure.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public Guid BasketId { get; set; }
        public Guid OrderId { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual Order Order { get; internal set; }
    }
}
