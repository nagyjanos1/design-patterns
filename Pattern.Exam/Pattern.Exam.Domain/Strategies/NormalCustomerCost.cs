using Pattern.Exam.Domain.Strategies.Interfaces;

namespace Pattern.Exam.Domain.Strategies
{
    public class NormalCustomerCost : ICustomerCost
    {
        public decimal GetTotalCost(Basket basket)
        {
            return basket.AddedProducts.Sum(p => p.Price);
        }
    }
}
