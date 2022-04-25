using Pattern.Exam.Domain;

namespace Pattern.Exam.Services.Interfaces
{
    public interface IOrderFacade
    {
        Task<Order> CreateAsync(Guid accountId);
    }
}