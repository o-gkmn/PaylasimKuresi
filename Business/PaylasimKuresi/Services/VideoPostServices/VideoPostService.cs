using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.VideoPostServices;
using DataAccess.Interfaces.VideoPostRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.VideoPostServices;

public class VideoPostService : IVideoPostService
{
    private readonly IVideoPostRepository _videoPostRepository;

    public VideoPostService(IVideoPostRepository videoPostRepository)
    {
        _videoPostRepository = videoPostRepository;
    }

    public async Task<VideoPost> CreateAsync(VideoPost entity)
    {
        var result = await _videoPostRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(VideoPost entity)
    {
        var result = await _videoPostRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<VideoPost?> GetAsync(Expression<Func<VideoPost, bool>> filter)
    {
        var result = await _videoPostRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<VideoPost>> GetListAsync(Expression<Func<VideoPost, bool>>? filter = null)
    {
        var result = await _videoPostRepository.GetListAsync(filter);
        return result;
    }

    public async Task<VideoPost> UpdateAsync(VideoPost entity)
    {
        var result = await _videoPostRepository.UpdateAsync(entity);
        return result;
    }
}
