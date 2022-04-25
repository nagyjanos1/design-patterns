using Pattern.Exam.Domain;

namespace Pattern.Exam.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetAsync(Guid productId);
    }
}
