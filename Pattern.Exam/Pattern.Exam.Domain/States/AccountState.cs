namespace Pattern.Exam.Domain.States
{
    public abstract class AccountState
    {
        public Account Account { get; protected set; }
        public int TotalCountOfOrder { get; protected set; }
        public decimal TotalCostofOrders { get; protected set; }

        protected int LowerLimitOfOrders { get; set; }
        protected int UpperLimitOfOrders { get; set; }
        protected decimal LowerLimitOfTotalCost { get; set; }
        protected decimal UpperLimitOfTotalCost { get; set; }

        public AccountState(Account account)
        {
            Account = account;
        }

        public abstract void AddNewOrder(Basket basket);

        public abstract void StateChangeCheck();
    }
}
