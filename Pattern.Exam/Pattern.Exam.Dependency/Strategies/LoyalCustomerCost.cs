using Pattern.Exam.Domain.Strategies.Interfaces;

namespace Pattern.Exam.Domain.Strategies
{
    public class LoyalCustomerCost : ICustomerCost
    {
        public decimal GetTotalCost(Basket basket)
        {
            var totalCost = basket.AddedProducts.Sum(p => p.Price);

            return totalCost - (totalCost * (decimal)0.1);
        }
    }
}
