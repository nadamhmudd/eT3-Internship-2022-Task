using CoffeeShopSystem.Models;
using CoffeeShopSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopSystem.Services.Implementation.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        #region Props / Vars
        protected readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructor(s)
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        #endregion

        #region Actions
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetALlAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
        #endregion
    }
}
