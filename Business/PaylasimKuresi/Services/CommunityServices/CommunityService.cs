using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.CommunityServices;
using DataAccess.Interfaces.CommunityRepositories;
using Models.DTOs.CommunityDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.CommunityServices;

public class CommunityService : ICommunityService
{
    private readonly ICommunityRepository _communityRepository;
    private readonly IMapper _mapper;

    public CommunityService(ICommunityRepository communityRepository, IMapper mapper)
    {
        _communityRepository = communityRepository;
        _mapper = mapper;
    }

    public async Task<GetCommunityDto> CreateAsync(CreateCommunityDto entityDto)
    {
        var entity = _mapper.Map<Community>(entityDto);
        var result = await _communityRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetCommunityDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetCommunityDto entityDto)
    {
        var entity = _mapper.Map<Community>(entityDto);
        var result = await _communityRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetCommunityDto?> GetAsync(Expression<Func<GetCommunityDto, bool>> filter)
    {
        var communityFilter = _mapper.MapExpression<Expression<Func<Community, bool>>>(filter);
        var result = await _communityRepository.GetAsync(communityFilter);

        var getEntityDto = _mapper.Map<GetCommunityDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetCommunityDto>> GetListAsync(Expression<Func<GetCommunityDto, bool>>? filter = null)
    {
        var communityFilter = _mapper.MapExpression<Expression<Func<Community, bool>>>(filter);
        var result = await _communityRepository.GetListAsync(communityFilter);

        var getEntityDtoList = _mapper.Map<List<GetCommunityDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetCommunityDto> UpdateAsync(UpdateCommunityDto entityDto)
    {
        var entity = _mapper.Map<Community>(entityDto);
        var result = await _communityRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetCommunityDto>(result);
        return updatedEntityDto;
    }
}
