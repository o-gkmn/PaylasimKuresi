using AuthenticationServiceApi.Data.Context;
using AuthenticationServiceApi.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServiceApi.Data.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly AuthContext _context;

        public RepositoryBase(AuthContext context)
        {
            this._context = context;
        }

        public async Task DeleteAsync(T entity)
        {
            //using var context = new AuthContext();
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            //using var context = new AuthContext();
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            //using var context = new AuthContext();
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            //using var context = new AuthContext();
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            //using var context = new AuthContext();
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
