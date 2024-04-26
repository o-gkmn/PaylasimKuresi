using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.GroupServices;
using DataAccess.Interfaces.GroupRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.GroupServices;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<Group> CreateAsync(Group entity)
    {
        var result = await _groupRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(Group entity)
    {
        var result = await _groupRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<Group?> GetAsync(Expression<Func<Group, bool>> filter)
    {
        var result = await _groupRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<Group>> GetListAsync(Expression<Func<Group, bool>>? filter = null)
    {
        var result = await _groupRepository.GetListAsync(filter);
        return result;
    }

    public async Task<Group> UpdateAsync(Group entity)
    {
        var result = await _groupRepository.UpdateAsync(entity);
        return result;
    }
}
