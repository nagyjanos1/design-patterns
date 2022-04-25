namespace Pattern.Exam.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public List<Product>? Products { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDiscounted { get; set; }
        public decimal TotalCost { get; set; }
        public Account Account { get; set; }
    }
}
