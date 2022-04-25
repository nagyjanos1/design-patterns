namespace Pattern.Exam.Domain.States
{
    public class NormalState : AccountState
    {
        public NormalState(Account account) : base(account)
        {
            LowerLimitOfTotalCost = 0;
            LowerLimitOfOrders = 0;

            UpperLimitOfTotalCost = 100000;
            UpperLimitOfOrders = 5;
        }

        public override void AddNewOrder(Basket basket)
        {
            var totalCostOfProducts = basket.AddedProducts.Sum(p => p.Price);
            var totalCostOfOrders = Account.Orders.Sum(o => o.TotalCost);

            if (IsGreaterThanLimitOfTotalCostOfOrder(basket) && IsGreaterThanLimitOfTotalCountOfOrder())
            {
                Account.State = new LoyalState(this);
            }
        }


        private bool IsGreaterThanLimitOfTotalCountOfOrder()
        {
            return (Account.Orders.Count + 1) > LowerLimitOfOrders;
        }

        private bool IsGreaterThanLimitOfTotalCostOfOrder(Basket basket)
        {
            var totalCostOfProducts = basket.AddedProducts.Sum(p => p.Price);
            var totalCostOfOrders = Account.Orders.Sum(o => o.TotalCost);

            return (totalCostOfProducts + totalCostOfOrders) > LowerLimitOfTotalCost;
        }

        private bool IsGreaterThanLimitOfTotalCostOfOrder()
        {
            var totalCostOfOrders = Account.Orders.Sum(o => o.TotalCost);

            return totalCostOfOrders > LowerLimitOfTotalCost;
        }

        public override void StateChangeCheck()
        {
            if (IsGreaterThanLimitOfTotalCostOfOrder() && IsGreaterThanLimitOfTotalCountOfOrder())
            {
                Account.State = new LoyalState(this);
            }
        }
    }
}
