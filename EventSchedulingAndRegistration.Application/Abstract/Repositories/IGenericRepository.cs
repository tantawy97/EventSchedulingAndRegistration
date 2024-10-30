using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedulingAndRegistration.Application.Abstract.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> GetBaseQuery(bool asNoTracking = false);
        Task<List<TEntity>> FindAllAsync(bool asNoTracking = false);
        Task<long> CountAllAsync();
        Task<TEntity> FindByIdAsync(Guid id, bool asNoTracking = false);
        Task CreateAsync(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null, bool asNoTracking = false); 



    }
}
