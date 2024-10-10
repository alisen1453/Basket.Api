using Basket.Api.Access.Context;
using Basket.Api.Core.Abstract;
using Basket.Api.Core.Response;
using Basket.Api.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Basket.Api.Access.Repository
{
    public class BasketRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly BasketDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public BasketRepository(BasketDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public IQueryable<TEntity> Query()
        {
            return _dbSet.AsQueryable();
            
        }
        public async Task AddAsync(TEntity entity)
        {
          await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
        public async Task UpdateAsync(TEntity entity)
        { 
          _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            
          return   await _dbSet.FindAsync(id);
           
             
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
        public async Task<int> SaveorUpdate()
        {
           return await _context.SaveChangesAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AnyAsync();
        }
    }
}
