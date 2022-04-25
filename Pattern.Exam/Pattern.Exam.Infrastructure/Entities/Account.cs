namespace Pattern.Exam.Infrastructure.Entities
{
    public class Account : BaseEntity
    {
        public Account()
        {
            Orders = new HashSet<Order>();
        }

        public string Number { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
