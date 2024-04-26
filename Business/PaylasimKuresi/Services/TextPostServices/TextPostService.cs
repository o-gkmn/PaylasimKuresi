using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.TextPostServices;
using DataAccess.Interfaces.TextPostRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.TextPostServices;

public class TextPostService : ITextPostService
{
    private readonly ITextPostRepository _textPostRepository;

    public TextPostService(ITextPostRepository textPostRepository)
    {
        _textPostRepository = textPostRepository;
    }

    public async Task<TextPost> CreateAsync(TextPost entity)
    {
        var result = await _textPostRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(TextPost entity)
    {
        var result = await _textPostRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<TextPost?> GetAsync(Expression<Func<TextPost, bool>> filter)
    {
        var result = await _textPostRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<TextPost>> GetListAsync(Expression<Func<TextPost, bool>>? filter = null)
    {
        var result = await _textPostRepository.GetListAsync(filter);
        return result;
    }

    public async Task<TextPost> UpdateAsync(TextPost entity)
    {
        var result = await _textPostRepository.UpdateAsync(entity);
        return result;
    }
}
