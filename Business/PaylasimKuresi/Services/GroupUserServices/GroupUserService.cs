using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.GroupServices;
using Business.PaylasimKuresi.Interfaces.GroupUserServices;
using DataAccess.Interfaces.GroupUserRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.GroupUserServices;

public class GroupUserService : IGroupUserService
{
    private readonly IGroupUserRepository _groupUserRepository;

    public GroupUserService(IGroupUserRepository groupUserRepository)
    {
        _groupUserRepository = groupUserRepository;
    }

    public async Task<GroupUser> CreateAsync(GroupUser entity)
    {
        var result = await _groupUserRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(GroupUser entity)
    {
        var result = await _groupUserRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<GroupUser?> GetAsync(Expression<Func<GroupUser, bool>> filter)
    {
        var result = await _groupUserRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<GroupUser>> GetListAsync(Expression<Func<GroupUser, bool>>? filter = null)
    {
        var result = await _groupUserRepository.GetListAsync(filter);
        return result;
    }

    public async Task<GroupUser> UpdateAsync(GroupUser entity)
    {
        var result = await _groupUserRepository.UpdateAsync(entity);
        return result;
    }
}
