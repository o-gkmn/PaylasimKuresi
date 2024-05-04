using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.PostLikeServices;
using DataAccess.Interfaces.PostLikeRepositories;
using Models.DTOs.PostLikeDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.PostLikeServices;

public class PostLikeService : IPostLikeService
{
    private readonly IPostLikeRepository _postLikeRepository;
    private readonly IMapper _mapper;

    public PostLikeService(IPostLikeRepository postLikeRepository, IMapper mapper)
    {
        _postLikeRepository = postLikeRepository;
        _mapper = mapper;
    }

    public async Task<GetPostLikeDto> CreateAsync(CreatePostLikeDto entityDto)
    {
        var entity = _mapper.Map<PostLike>(entityDto);
        var result = await _postLikeRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetPostLikeDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetPostLikeDto entityDto)
    {
        var entity = _mapper.Map<PostLike>(entityDto);
        var result = await _postLikeRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetPostLikeDto?> GetAsync(Expression<Func<GetPostLikeDto, bool>> filter)
    {
        var postLikeFilter = _mapper.MapExpression<Expression<Func<PostLike, bool>>>(filter);
        var result = await _postLikeRepository.GetAsync(postLikeFilter);

        var getEntityDto = _mapper.Map<GetPostLikeDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetPostLikeDto>> GetListAsync(Expression<Func<GetPostLikeDto, bool>>? filter = null)
    {
        var postLikeFilter = _mapper.MapExpression<Expression<Func<PostLike, bool>>>(filter);
        var result = await _postLikeRepository.GetListAsync(postLikeFilter);

        var getEntityDtoList = _mapper.Map<List<GetPostLikeDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetPostLikeDto> UpdateAsync(UpdatePostLikeDto entityDto)
    {
        var entity = _mapper.Map<PostLike>(entityDto);
        var result = await _postLikeRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetPostLikeDto>(result);
        return updatedEntityDto;
    }
}
