using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.CommunityUserServices;
using DataAccess.Interfaces.CommunityUserRepositories;
using Models.DTOs.CommunityUserDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.CommunityUserServices;

public class CommunityUserService : ICommunityUserService
{
    private readonly ICommunityUserRepository _communityUserRepository;
    private readonly IMapper _mapper;

    public CommunityUserService(ICommunityUserRepository communityUserRepository, IMapper mapper)
    {
        _communityUserRepository = communityUserRepository;
        _mapper = mapper;
    }

    public async Task<GetCommunityUserDto> CreateAsync(CreateCommunityUserDto entityDto)
    {
        var entity = _mapper.Map<CommunityUser>(entityDto);
        var result = await _communityUserRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetCommunityUserDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetCommunityUserDto entityDto)
    {
        var entity = _mapper.Map<CommunityUser>(entityDto);
        var result = await _communityUserRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetCommunityUserDto?> GetAsync(Expression<Func<GetCommunityUserDto, bool>> filter)
    {
        var communityUserFilter = _mapper.MapExpression<Expression<Func<CommunityUser, bool>>>(filter);
        var result = await _communityUserRepository.GetAsync(communityUserFilter);

        var getEntityDto = _mapper.Map<GetCommunityUserDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetCommunityUserDto>> GetListAsync(Expression<Func<GetCommunityUserDto, bool>>? filter = null)
    {
        var communityUserFilter = _mapper.MapExpression<Expression<Func<CommunityUser, bool>>>(filter);
        var result = await _communityUserRepository.GetListAsync(communityUserFilter);

        var getEntityDtoList = _mapper.Map<List<GetCommunityUserDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetCommunityUserDto> UpdateAsync(UpdateCommunityUserDto entityDto)
    {
        var entity = _mapper.Map<CommunityUser>(entityDto);
        var result = await _communityUserRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetCommunityUserDto>(result);
        return updatedEntityDto;
    }
}
