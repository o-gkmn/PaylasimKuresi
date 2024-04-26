using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.RoleServices;
using DataAccess.Interfaces.RoleRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.RoleServices;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Role> CreateAsync(Role entity)
    {
        var result = await _roleRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(Role entity)
    {
        var result = await _roleRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<Role?> GetAsync(Expression<Func<Role, bool>> filter)
    {
        var result = await _roleRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<Role>> GetListAsync(Expression<Func<Role, bool>>? filter = null)
    {
        var result = await _roleRepository.GetListAsync(filter);
        return result;
    }

    public async Task<Role> UpdateAsync(Role entity)
    {
        var result = await _roleRepository.UpdateAsync(entity);
        return result;
    }
}
