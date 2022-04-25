using Pattern.Exam.Infrastructure.Entities;
using Pattern.Exam.Infrastructure.Repositories;

namespace Pattern.Exam.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly WebShopDbContext _context;

        public UnitOfWork(WebShopDbContext context)
        {
            _context = context;
        }


        public IGenericRepository<T> GetGenericRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_context);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
