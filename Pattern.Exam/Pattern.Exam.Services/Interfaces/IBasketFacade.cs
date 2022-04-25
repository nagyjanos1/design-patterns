using Pattern.Exam.Domain;

namespace Pattern.Exam.Services.Interfaces
{
    public interface IBasketFacade
    {
        Task AddAsync(Guid accountId, Guid productId);
        Task RemoveAsync(Guid accountId, Guid productId);
        Task<Basket> GetAsync(Guid accountId);
    }
}
