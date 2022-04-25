using Pattern.Exam.Infrastructure.Entities;
using Pattern.Exam.Infrastructure.Repositories;

namespace Pattern.Exam.Infrastructure
{
    public interface IUnitOfWork
    {
        bool SaveChanges();

        Task<bool> SaveChangesAsync();

        IGenericRepository<T> GetGenericRepository<T>() where T : BaseEntity;
    }
}
