using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.GroupServices;
using DataAccess.Interfaces.GroupRepositories;
using Models.DTOs.GroupDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.GroupServices;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public GroupService(IGroupRepository groupRepository, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
    }

    public async Task<GetGroupDto> CreateAsync(CreateGroupDto entityDto)
    {
        var entity = _mapper.Map<Group>(entityDto);
        var result = await _groupRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetGroupDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetGroupDto entityDto)
    {
        var entity = _mapper.Map<Group>(entityDto);
        var result = await _groupRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetGroupDto?> GetAsync(Expression<Func<GetGroupDto, bool>> filter)
    {
        var groupFilter = _mapper.MapExpression<Expression<Func<Group, bool>>>(filter);
        var result = await _groupRepository.GetAsync(groupFilter);

        var getEntityDto = _mapper.Map<GetGroupDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetGroupDto>> GetListAsync(Expression<Func<GetGroupDto, bool>>? filter = null)
    {
        var groupFilter = _mapper.MapExpression<Expression<Func<Group, bool>>>(filter);
        var result = await _groupRepository.GetListAsync(groupFilter);

        var getEntityDtoList = _mapper.Map<List<GetGroupDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetGroupDto> UpdateAsync(UpdateGroupDto entityDto)
    {
        var entity = _mapper.Map<Group>(entityDto);
        var result = await _groupRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetGroupDto>(result);
        return updatedEntityDto;
    }
}
