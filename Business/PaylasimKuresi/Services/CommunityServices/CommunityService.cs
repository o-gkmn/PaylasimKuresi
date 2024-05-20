using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.CommunityServices;
using Business.PaylasimKuresi.Interfaces.CommunityUserServices;
using DataAccess.Interfaces.CommunityRepositories;
using Models.DTOs.CommunityDTOs;
using Models.DTOs.CommunityUserDTOs;
using Models.Entities;
using Models.Errors;

namespace Business.PaylasimKuresi.Services.CommunityServices;

public class CommunityService : ICommunityService
{
    private readonly ICommunityRepository _communityRepository;
    private readonly ICommunityUserService _communityUserService;
    private readonly IMapper _mapper;

    public CommunityService(ICommunityRepository communityRepository, IMapper mapper, ICommunityUserService communityUserService)
    {
        _communityRepository = communityRepository;
        _mapper = mapper;
        _communityUserService = communityUserService;
    }

    public async Task<GetCommunityDto> CreateAsync(CreateCommunityDto entityDto)
    {
        var entity = _mapper.Map<Community>(entityDto);
        var result = await _communityRepository.CreateAsync(entity);

        if (result == null)
            throw CommunityError.CommunityNotCreated;

        var createCommunityUserDto = new CreateCommunityUserDto
        {
            CommunityID = result.ID,
            JoinedAt = DateTime.Now,
            UserID = result.FounderID,
            RoleID = Guid.Empty
        };

        await _communityUserService.CreateAsync(createCommunityUserDto);

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
