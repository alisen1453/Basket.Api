using System.Linq.Expressions;

namespace Basket.Core.Abstract
{
    public interface IRepository<TEntity> : IEntity where TEntity : class, IEntity
    {
        IQueryable<TEntity> Query();
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<int> SaveorUpdate();

    }
}
