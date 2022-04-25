using Pattern.Exam.Domain.States;

namespace Pattern.Exam.Domain
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public AccountState State { get; set; }
        public List<Order> Orders { get; set; }
        public DateTime CreateDate { get; set; }

        public Account()
        {
            State = new NormalState(this);
            State.StateChangeCheck();
        }
    }
}
