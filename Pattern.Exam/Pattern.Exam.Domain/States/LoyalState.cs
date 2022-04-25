namespace Pattern.Exam.Domain.States
{
    public class LoyalState : AccountState
    {
        public LoyalState(Account account) : base(account)
        {
            LowerLimitOfTotalCost = 100001;
            LowerLimitOfOrders = 6;
        }

        public LoyalState(AccountState accountState) : this(accountState.Account)
        {
            TotalCountOfOrder = accountState.TotalCountOfOrder;
            TotalCostofOrders = accountState.TotalCostofOrders;
        }

        public override void AddNewOrder(Basket basket)
        {

        }

        public override void StateChangeCheck()
        {
            
        }
    }
}
