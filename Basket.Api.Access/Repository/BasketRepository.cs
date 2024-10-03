using Basket.Api.Access.Context;
using Basket.Api.Core.Abstract;
using Basket.Api.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

         _context.SaveChanges();
         
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task GetAll(List<TEntity> entity)
        {
            await _dbSet.ToListAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public async Task<TEntity> GetById(Guid id)
        {
          
          var data= await _dbSet.FindAsync(id);
            return data;

        }

        public async Task<int> Save()
        {
           return await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            
          _dbSet.Update(entity);
            await _context.SaveChangesAsync();

        }

      
    }
}
