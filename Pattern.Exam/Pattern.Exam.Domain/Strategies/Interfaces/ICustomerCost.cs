namespace Pattern.Exam.Domain.Strategies.Interfaces
{
    public interface ICustomerCost
    {
        decimal GetTotalCost(Basket basket);
    }
}
