using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.CommentLikeServices;
using Business.PaylasimKuresi.Interfaces.UserServices;
using DataAccess.Interfaces.CommentLikeRepositories;
using Microsoft.AspNetCore.Http;
using Models.DTOs.CommentLikeDTOs;
using Models.Entities;
using Models.Errors;

namespace Business.PaylasimKuresi.Services.CommentLikeServices;

public class CommentLikeService : ICommentLikeService
{
    private readonly ICommentLikeRepository _commentLikeRepository;
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public CommentLikeService(ICommentLikeRepository commentLikeRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IUserService userService)
    {
        _commentLikeRepository = commentLikeRepository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _userService = userService;
    }

    public async Task<GetCommentLikeDto> CreateAsync(CreateCommentLikeDto entityDto)
    {
        var entity = _mapper.Map<CommentLike>(entityDto);
        var httpContext = _httpContextAccessor.HttpContext
                ?? throw ServerError.HttpContextUnavailable;

        if (httpContext.User == null)
            throw SessionError.UserNotAuthenticated;

        var user = await _userService.RetrieveUserByPrincipalAsync(httpContext.User)
            ?? throw UserError.UserNotFound;

        if (user.CommentLikes != null)
        {
            var userCommentLikes = user.CommentLikes.Where(commentLike => commentLike.CommentID == entityDto.CommentID);
            if (userCommentLikes.Any())
                throw DuplicateError.PostAlreadyLiked;
        }

        var result = await _commentLikeRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetCommentLikeDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetCommentLikeDto entityDto)
    {
        var entity = _mapper.Map<CommentLike>(entityDto);
        var result = await _commentLikeRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetCommentLikeDto?> GetAsync(Expression<Func<GetCommentLikeDto, bool>> filter)
    {
        var commentLikeFilter = _mapper.MapExpression<Expression<Func<CommentLike, bool>>>(filter);
        var result = await _commentLikeRepository.GetAsync(commentLikeFilter);

        var getEntityDto = _mapper.Map<GetCommentLikeDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetCommentLikeDto>> GetListAsync(Expression<Func<GetCommentLikeDto, bool>>? filter = null)
    {
        var commentLikeFilter = _mapper.MapExpression<Expression<Func<CommentLike, bool>>>(filter);
        var result = await _commentLikeRepository.GetListAsync(commentLikeFilter);

        var getEntityDtoList = _mapper.Map<List<GetCommentLikeDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetCommentLikeDto> UpdateAsync(UpdateCommentLikeDto entityDto)
    {
        var entity = _mapper.Map<CommentLike>(entityDto);
        var result = await _commentLikeRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetCommentLikeDto>(result);
        return updatedEntityDto;
    }
}
