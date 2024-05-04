using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.FollowServices;
using DataAccess.Interfaces.FollowRepositories;
using Models.DTOs.FollowDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.FollowServices;

public class FollowService : IFollowService
{
    private readonly IFollowRepository _followRepository;
    private readonly IMapper _mapper;

    public FollowService(IFollowRepository followRepository, IMapper mapper)
    {
        _followRepository = followRepository;
        _mapper = mapper;
    }

    public async Task<GetFollowDto> CreateAsync(CreateFollowDto entityDto)
    {
        var entity = _mapper.Map<Follow>(entityDto);
        var result = await _followRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetFollowDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetFollowDto entityDto)
    {
        var entity = _mapper.Map<Follow>(entityDto);
        var result = await _followRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetFollowDto?> GetAsync(Expression<Func<GetFollowDto, bool>> filter)
    {
        var followFilter = _mapper.MapExpression<Expression<Func<Follow, bool>>>(filter);
        var result = await _followRepository.GetAsync(followFilter);

        var getEntityDto = _mapper.Map<GetFollowDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetFollowDto>> GetListAsync(Expression<Func<GetFollowDto, bool>>? filter = null)
    {
        var followFilter = _mapper.MapExpression<Expression<Func<Follow, bool>>>(filter);
        var result = await _followRepository.GetListAsync(followFilter);

        var getEntityDtoList = _mapper.Map<List<GetFollowDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetFollowDto> UpdateAsync(UpdateFollowDto entityDto)
    {
        var entity = _mapper.Map<Follow>(entityDto);
        var result = await _followRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetFollowDto>(result);
        return updatedEntityDto;
    }
}
