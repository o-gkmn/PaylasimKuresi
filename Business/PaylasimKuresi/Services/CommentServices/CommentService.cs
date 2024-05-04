using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.CommentServices;
using DataAccess.Interfaces.CommentRepositories;
using Models.DTOs.CommentDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.CommentServices;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<GetCommentDto> CreateAsync(CreateCommentDto entityDto)
    {
        var entity = _mapper.Map<Comment>(entityDto);
        var result = await _commentRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetCommentDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetCommentDto entityDto)
    {
        var entity = _mapper.Map<Comment>(entityDto);
        var result = await _commentRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetCommentDto?> GetAsync(Expression<Func<GetCommentDto, bool>> filter)
    {
        var commentFilter = _mapper.MapExpression<Expression<Func<Comment, bool>>>(filter);
        var result = await _commentRepository.GetAsync(commentFilter);

        var getEntityDto = _mapper.Map<GetCommentDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetCommentDto>> GetListAsync(Expression<Func<GetCommentDto, bool>>? filter = null)
    {
        var commentFilter = _mapper.MapExpression<Expression<Func<Comment, bool>>>(filter);
        var result = await _commentRepository.GetListAsync(commentFilter);

        var getEntityDtoList = _mapper.Map<List<GetCommentDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetCommentDto> UpdateAsync(UpdateCommentDto entityDto)
    {
        var entity = _mapper.Map<Comment>(entityDto);
        var result = await _commentRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetCommentDto>(result);
        return updatedEntityDto;
    }
}
