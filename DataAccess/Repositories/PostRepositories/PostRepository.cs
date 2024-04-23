using System.Linq.Expressions;
using DataAccess.DbContext;
using DataAccess.Interfaces.PostRepositories;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.Repositories.PostRepositories;

public class PostRepository : IPostRepository
{
    private readonly EFContext _context;

    public PostRepository(EFContext context)
    {
        _context = context;
    }

    public async Task<Post> CreateAsync(Post entity)
    {
        var result = await _context.Posts.AddAsync(entity);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<bool> DeleteAsync(Post entity)
    {
        var result = _context.Posts.Remove(entity);
        var isSaved = await _context.SaveChangesAsync();

        return isSaved == 1 ? true : false;
    }

    public async Task<Post?> GetAsync(Expression<Func<Post, bool>> filter)
    {
        var entity = await _context.Posts.FirstOrDefaultAsync(filter);
        return entity ?? null;
    }

    public async Task<List<Post>> GetListAsync(Expression<Func<Post, bool>>? filter = null)
    {
        if (filter != null)
            return await _context.Posts.Where(filter).ToListAsync();
        else
            return await _context.Posts.ToListAsync();
    }

    public async Task<Post> UpdateAsync(Post entity)
    {
        var result = _context.Posts.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
