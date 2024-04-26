using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.CommentServices;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.CommentServices;

public class CommentService : ICommentService
{
    private readonly ICommentService _commentRepository;

    public CommentService(ICommentService commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<Comment> CreateAsync(Comment entity)
    {
        var result = await _commentRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(Comment entity)
    {
        var result = await _commentRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<Comment?> GetAsync(Expression<Func<Comment, bool>> filter)
    {
        var result = await _commentRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<Comment>> GetListAsync(Expression<Func<Comment, bool>>? filter = null)
    {
        var result = await _commentRepository.GetListAsync(filter);
        return result;
    }

    public async Task<Comment> UpdateAsync(Comment entity)
    {
        var result = await _commentRepository.UpdateAsync(entity);
        return result;
    }
}
