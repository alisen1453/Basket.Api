using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Core.Abstract
{
    public interface IRepository<TEntity> : IEntity where TEntity :class, IEntity
    {
        IQueryable<TEntity> Query();
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task GetAll(List<TEntity> entity);
        Task AddAsync(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        
        Task<int> Save();
        
    }
}
