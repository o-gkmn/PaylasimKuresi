using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.CommentLikeServices;
using DataAccess.Interfaces.CommentLikeRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.CommentLikeServices;

public class CommentLikeService : ICommentLikeService
{
    private readonly ICommentLikeRepository _commentLikeRepository;

    public CommentLikeService(ICommentLikeRepository commentLikeRepository)
    {
        _commentLikeRepository = commentLikeRepository;
    }

    public async Task<CommentLike> CreateAsync(CommentLike entity)
    {
        var result = await _commentLikeRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(CommentLike entity)
    {
        var result = await _commentLikeRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<CommentLike?> GetAsync(Expression<Func<CommentLike, bool>> filter)
    {
        var result = await _commentLikeRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<CommentLike>> GetListAsync(Expression<Func<CommentLike, bool>>? filter = null)
    {
        var result = await _commentLikeRepository.GetListAsync(filter);
        return result;
    }

    public async Task<CommentLike> UpdateAsync(CommentLike entity)
    {
        var result = await _commentLikeRepository.UpdateAsync(entity);
        return result;
    }
}
