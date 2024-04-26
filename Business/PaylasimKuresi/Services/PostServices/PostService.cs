using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.PostServices;
using DataAccess.Interfaces.PostRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.PostServices;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post> CreateAsync(Post entity)
    {
        var result = await _postRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(Post entity)
    {
        var result = await _postRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<Post?> GetAsync(Expression<Func<Post, bool>> filter)
    {
        var result = await _postRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<Post>> GetListAsync(Expression<Func<Post, bool>>? filter = null)
    {
        var result = await _postRepository.GetListAsync(filter);
        return result;
    }

    public async Task<Post> UpdateAsync(Post entity)
    {
        var result = await _postRepository.UpdateAsync(entity);
        return result;
    }
}
