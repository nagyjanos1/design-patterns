using Pattern.Exam.Domain;

namespace Pattern.Exam.Services.Interfaces
{
    public interface IBasketService
    {
        Task<Basket> GetAsync(Guid accountId);
        Task SaveAsync(Basket basket);
    }
}
