using Pattern.Exam.Domain;

namespace Pattern.Exam.Services.Interfaces
{
    public interface IOrderService
    {
        Task SaveAsync(Order order);

        Task<Order> GetAsync(Guid accountId);
    }
}