using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.VoicePostServices;
using DataAccess.Interfaces.VoicePostRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.VoicePostServices;

public class VoicePostService : IVoicePostService
{
    private readonly IVoicePostRepository _voicePostRepository;

    public VoicePostService(IVoicePostRepository voicePostRepository)
    {
        _voicePostRepository = voicePostRepository;
    }

    public async Task<VoicePost> CreateAsync(VoicePost entity)
    {
        var result = await _voicePostRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(VoicePost entity)
    {
        var result = await _voicePostRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<VoicePost?> GetAsync(Expression<Func<VoicePost, bool>> filter)
    {
        var result = await _voicePostRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<VoicePost>> GetListAsync(Expression<Func<VoicePost, bool>>? filter = null)
    {
        var result = await _voicePostRepository.GetListAsync(filter);
        return result;
    }

    public async Task<VoicePost> UpdateAsync(VoicePost entity)
    {
        var result = await _voicePostRepository.UpdateAsync(entity);
        return result;
    }
}
