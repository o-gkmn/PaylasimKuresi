using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.CommunityServices;
using Business.PaylasimKuresi.Interfaces.CommunityUserServices;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.CommunityServices;

public class CommunityService : ICommunityService
{
    private readonly ICommunityService _communityRepository;

    public CommunityService(ICommunityService communityRepository)
    {
        _communityRepository = communityRepository;
    }

    public async Task<Community> CreateAsync(Community entity)
    {
        var result = await _communityRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(Community entity)
    {
        var result = await _communityRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<Community?> GetAsync(Expression<Func<Community, bool>> filter)
    {
        var result = await _communityRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<Community>> GetListAsync(Expression<Func<Community, bool>>? filter = null)
    {
        var result = await _communityRepository.GetListAsync(filter);
        return result;
    }

    public async Task<Community> UpdateAsync(Community entity)
    {
        var result = await _communityRepository.UpdateAsync(entity);
        return result;
    }
}
