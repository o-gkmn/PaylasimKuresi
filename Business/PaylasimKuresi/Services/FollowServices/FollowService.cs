using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.FollowServices;
using DataAccess.Interfaces.FollowRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.FollowServices;

public class FollowService : IFollowService
{
    private readonly IFollowRepository _followRepository;

    public FollowService(IFollowRepository followRepository)
    {
        _followRepository = followRepository;
    }

    public async Task<Follow> CreateAsync(Follow entity)
    {
        var result = await _followRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(Follow entity)
    {
        var result = await _followRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<Follow?> GetAsync(Expression<Func<Follow, bool>> filter)
    {
        var result = await _followRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<Follow>> GetListAsync(Expression<Func<Follow, bool>>? filter = null)
    {
        var result = await _followRepository.GetListAsync(filter);
        return result;
    }

    public async Task<Follow> UpdateAsync(Follow entity)
    {
        var result = await _followRepository.UpdateAsync(entity);
        return result;
    }
}
