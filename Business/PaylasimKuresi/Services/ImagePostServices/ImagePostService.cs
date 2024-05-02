using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.ImagePostServices;
using DataAccess.Interfaces.ImagePostRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.ImagePostServices;

public class ImagePostService : IImagePostService
{
    private readonly IImagePostRepository _imagePostRepository;

    public ImagePostService(IImagePostRepository imagePostRepository)
    {
        _imagePostRepository = imagePostRepository;
    }

    public async Task<ImagePost> CreateAsync(ImagePost entity)
    {
        var result = await _imagePostRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(ImagePost entity)
    {
        var result = await _imagePostRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<ImagePost?> GetAsync(Expression<Func<ImagePost, bool>> filter)
    {
        var result = await _imagePostRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<ImagePost>> GetListAsync(Expression<Func<ImagePost, bool>>? filter = null)
    {
        var result = await _imagePostRepository.GetListAsync(filter);
        return result;
    }

    public async Task<ImagePost> UpdateAsync(ImagePost entity)
    {
        var result = await _imagePostRepository.UpdateAsync(entity);
        return result;
    }
}
