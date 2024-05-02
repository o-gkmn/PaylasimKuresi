using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.CommunityUserServices;
using DataAccess.Interfaces.CommunityUserRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.CommunityUserServices;

public class CommunityUserService : ICommunityUserService
{
    private readonly ICommunityUserRepository _communityUserRepository;

    public CommunityUserService(ICommunityUserRepository communityUserRepository)
    {
        _communityUserRepository = communityUserRepository;
    }

    public async Task<CommunityUser> CreateAsync(CommunityUser entity)
    {
        var result = await _communityUserRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(CommunityUser entity)
    {
        var result = await _communityUserRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<CommunityUser?> GetAsync(Expression<Func<CommunityUser, bool>> filter)
    {
        var result = await _communityUserRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<CommunityUser>> GetListAsync(Expression<Func<CommunityUser, bool>>? filter = null)
    {
        var result = await _communityUserRepository.GetListAsync(filter);
        return result;
    }

    public async Task<CommunityUser> UpdateAsync(CommunityUser entity)
    {
        var result = await _communityUserRepository.UpdateAsync(entity);
        return result;
    }
}
