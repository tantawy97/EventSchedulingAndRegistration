using EventSchedulingAndRegistration.Application.Abstract.Repositories;
using EventSchedulingAndRegistration.Domain.Abstract;
using EventSchedulingAndRegistration.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventSchedulingAndRegistration.Infrastructure.Implementations.Repositories
{
    public class GenericRepository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity> where TEntity : Entity
    {
        public readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        internal DbSet<TEntity> dbSet = context.Set<TEntity>();
        public IQueryable<TEntity> GetBaseQuery(bool asNoTracking = false)
        {
            var query = dbSet.AsQueryable();

            query = asNoTracking ? query.AsNoTracking() : query;

            return query;
        }
        public async Task<List<TEntity>> FindAllAsync(bool asNoTracking = false)
            => await GetBaseQuery(asNoTracking).ToListAsync();
        public async Task<long> CountAllAsync()
            => await GetBaseQuery().LongCountAsync();

        public async Task<TEntity> FindByIdAsync(Guid id, bool asNoTracking = false)
            => await GetBaseQuery(asNoTracking).FirstOrDefaultAsync(e => e.Id == id);
        public async Task CreateAsync(TEntity entity) => await dbSet.AddAsync(entity);
        public void Update(TEntity entity) => dbSet.Update(entity);
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null, bool asNoTracking = false)
        => filter == null ? await GetBaseQuery(asNoTracking).AnyAsync() : await GetBaseQuery(asNoTracking).AnyAsync(filter);

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }
    }
}
