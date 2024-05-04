using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.GroupUserServices;
using DataAccess.Interfaces.GroupUserRepositories;
using Models.DTOs.GroupUserDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.GroupUserServices;

public class GroupUserService : IGroupUserService
{
    private readonly IGroupUserRepository _groupUserRepository;
    private readonly IMapper _mapper;

    public GroupUserService(IGroupUserRepository groupUserRepository, IMapper mapper)
    {
        _groupUserRepository = groupUserRepository;
        _mapper = mapper;
    }

    public async Task<GetGroupUserDto> CreateAsync(CreateGroupUserDto entityDto)
    {
        var entity = _mapper.Map<GroupUser>(entityDto);
        var result = await _groupUserRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetGroupUserDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetGroupUserDto entityDto)
    {
        var entity = _mapper.Map<GroupUser>(entityDto);
        var result = await _groupUserRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetGroupUserDto?> GetAsync(Expression<Func<GetGroupUserDto, bool>> filter)
    {
        var groupUserFilter = _mapper.MapExpression<Expression<Func<GroupUser, bool>>>(filter);
        var result = await _groupUserRepository.GetAsync(groupUserFilter);

        var getEntityDto = _mapper.Map<GetGroupUserDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetGroupUserDto>> GetListAsync(Expression<Func<GetGroupUserDto, bool>>? filter = null)
    {
        var groupUserFilter = _mapper.MapExpression<Expression<Func<GroupUser, bool>>>(filter);
        var result = await _groupUserRepository.GetListAsync(groupUserFilter);

        var getEntityDtoList = _mapper.Map<List<GetGroupUserDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetGroupUserDto> UpdateAsync(UpdateGroupUserDto entityDto)
    {
        var entity = _mapper.Map<GroupUser>(entityDto);
        var result = await _groupUserRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetGroupUserDto>(result);
        return updatedEntityDto;
    }
}
