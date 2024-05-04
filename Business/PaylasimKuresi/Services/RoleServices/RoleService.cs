using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.RoleServices;
using DataAccess.Interfaces.RoleRepositories;
using Models.DTOs.RoleDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.RoleServices;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public RoleService(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<GetRoleDto> CreateAsync(CreateRoleDto entityDto)
    {
        var entity = _mapper.Map<Role>(entityDto);
        var result = await _roleRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetRoleDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetRoleDto entityDto)
    {
        var entity = _mapper.Map<Role>(entityDto);
        var result = await _roleRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetRoleDto?> GetAsync(Expression<Func<GetRoleDto, bool>> filter)
    {
        var roleFilter = _mapper.MapExpression<Expression<Func<Role, bool>>>(filter);
        var result = await _roleRepository.GetAsync(roleFilter);

        var getEntityDto = _mapper.Map<GetRoleDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetRoleDto>> GetListAsync(Expression<Func<GetRoleDto, bool>>? filter = null)
    {
        var roleFilter = _mapper.MapExpression<Expression<Func<Role, bool>>>(filter);
        var result = await _roleRepository.GetListAsync(roleFilter);

        var getEntityDtoList = _mapper.Map<List<GetRoleDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetRoleDto> UpdateAsync(UpdateRoleDto entityDto)
    {
        var entity = _mapper.Map<Role>(entityDto);
        var result = await _roleRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetRoleDto>(result);
        return updatedEntityDto;
    }
}
