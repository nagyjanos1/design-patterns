using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pattern.Exam.Infrastructure.Entities;

namespace Pattern.Exam.Infrastructure.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<P>(params Expression<Func<T, P>>[] includes) where P : BaseEntity
        {
            return await QueryWithIncludes(includes).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<P>(Expression<Func<T, bool>> filter, params Expression<Func<T, P>>[] includes) where P : BaseEntity
        {
            return await QueryWithIncludes(includes).Where(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<P>(params Expression<Func<T, ICollection<P>>>[] includes) where P : BaseEntity
        {
            return await QueryWithIncludes(includes).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<P>(Expression<Func<T, bool>> filter, params Expression<Func<T, ICollection<P>>>[] includes) where P : BaseEntity
        {
            return await QueryWithIncludes(includes).Where(filter).ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetAsync<P>(Guid id, params Expression<Func<T, P>>[] includes) where P : BaseEntity
        {
            return await QueryWithIncludes(includes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetAsync<P>(Expression<Func<T, bool>> filter, params Expression<Func<T, P>>[] includes) where P : BaseEntity
        {
            return await QueryWithIncludes(includes).FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetAsync<P>(Guid id, params Expression<Func<T, ICollection<P>>>[] includes) where P : BaseEntity
        {
            return await QueryWithIncludes(includes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetAsync<P>(Expression<Func<T, bool>> filter, params Expression<Func<T, ICollection<P>>>[] includes) where P : BaseEntity
        {
            return await QueryWithIncludes(includes).FirstOrDefaultAsync(filter);
        }

        public T Update(T entity)
        {
            var entry = _dbSet.Update(entity);

            return entry.Entity;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        private IQueryable<T> QueryWithIncludes<P>(params Expression<Func<T, P>>[] includes) where P : BaseEntity
        {
            var query = _dbSet.AsQueryable<T>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        private IQueryable<T> QueryWithIncludes<P>(params Expression<Func<T, ICollection<P>>>[] includes) where P : BaseEntity
        {
            var query = _dbSet.AsQueryable<T>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }
    }
}
