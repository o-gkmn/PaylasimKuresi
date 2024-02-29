using DataAccess.DbContext;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class RepositoryBase<T>(AuthContext context) : IRepositoryBase<T>
    where T : class
{
    private readonly AuthContext _context = context;

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