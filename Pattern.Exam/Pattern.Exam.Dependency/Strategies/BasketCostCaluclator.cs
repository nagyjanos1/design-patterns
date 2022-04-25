using Pattern.Exam.Domain.Strategies.Interfaces;

namespace Pattern.Exam.Domain.Strategies
{
    public class BasketCostCaluclator : IBasketCostCalculator
    {
        private readonly ICustomerCost _customerCost;

        public BasketCostCaluclator(ICustomerCost customerCost)
        {
            _customerCost = customerCost;
        }

        public decimal GetBasketTotalCost(Basket basket)
        {
            return _customerCost.GetTotalCost(basket);
        }
    }
}
