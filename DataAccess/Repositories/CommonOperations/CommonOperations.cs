using System.Linq.Expressions;
using DataAccess.DbContext;
using DataAccess.Interfaces.CommonOperations;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.CommonOperations
{
    public class CommonOperations<T> : ICommonOperations<T> where T : class
    {
        private readonly EFContext _dbContext;

        public CommonOperations(EFContext context)
        {
            _dbContext = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var result = await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Remove(entity);
                var rowsAffected = await _dbContext.SaveChangesAsync();
                return rowsAffected > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
        {
            var result = await _dbContext.Set<T>().FirstOrDefaultAsync(filter);

            return result;
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
                return await _dbContext.Set<T>().ToListAsync();
            else
                return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
