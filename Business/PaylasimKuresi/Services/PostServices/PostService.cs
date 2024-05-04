using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.PostServices;
using DataAccess.Interfaces.PostRepositories;
using Models.DTOs.PostDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.PostServices;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<GetPostDto> CreateAsync(CreatePostDto entityDto)
    {
        var entity = _mapper.Map<Post>(entityDto);
        var result = await _postRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetPostDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetPostDto entityDto)
    {
        var entity = _mapper.Map<Post>(entityDto);
        var result = await _postRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetPostDto?> GetAsync(Expression<Func<GetPostDto, bool>> filter)
    {
        var postFilter = _mapper.MapExpression<Expression<Func<Post, bool>>>(filter);
        var result = await _postRepository.GetAsync(postFilter);

        var getEntityDto = _mapper.Map<GetPostDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetPostDto>> GetListAsync(Expression<Func<GetPostDto, bool>>? filter = null)
    {
        var postFilter = _mapper.MapExpression<Expression<Func<Post, bool>>>(filter);
        var result = await _postRepository.GetListAsync(postFilter);

        var getEntityDtoList = _mapper.Map<List<GetPostDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetPostDto> UpdateAsync(UpdatePostDto entityDto)
    {
        var entity = _mapper.Map<Post>(entityDto);
        var result = await _postRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetPostDto>(result);
        return updatedEntityDto;
    }
}
