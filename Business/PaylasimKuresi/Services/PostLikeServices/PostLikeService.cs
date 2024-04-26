using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.PostLikeServices;
using DataAccess.Interfaces.PostLikeRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.PostLikeServices;

public class PostLikeService : IPostLikeService
{
    private readonly IPostLikeRepository _postLikeRepository;

    public PostLikeService(IPostLikeRepository postLikeRepository)
    {
        _postLikeRepository = postLikeRepository;
    }

    public async Task<PostLike> CreateAsync(PostLike entity)
    {
        var result = await _postLikeRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(PostLike entity)
    {
        var result = await _postLikeRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<PostLike?> GetAsync(Expression<Func<PostLike, bool>> filter)
    {
        var result = await _postLikeRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<PostLike>> GetListAsync(Expression<Func<PostLike, bool>>? filter = null)
    {
        var result = await _postLikeRepository.GetListAsync(filter);
        return result;
    }

    public async Task<PostLike> UpdateAsync(PostLike entity)
    {
        var result = await _postLikeRepository.UpdateAsync(entity);
        return result;
    }
}
