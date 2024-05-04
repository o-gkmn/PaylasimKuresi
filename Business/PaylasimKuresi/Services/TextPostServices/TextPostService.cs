using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.TextPostServices;
using DataAccess.Interfaces.TextPostRepositories;
using Models.DTOs.TextPostDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.TextPostServices;

public class TextPostService : ITextPostService
{
    private readonly ITextPostRepository _textPostRepository;
    private readonly IMapper _mapper;

    public TextPostService(ITextPostRepository textPostRepository, IMapper mapper)
    {
        _textPostRepository = textPostRepository;
        _mapper = mapper;
    }

    public async Task<GetTextPostDto> CreateAsync(CreateTextPostDto entityDto)
    {
        var entity = _mapper.Map<TextPost>(entityDto);
        var result = await _textPostRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetTextPostDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetTextPostDto entityDto)
    {
        var entity = _mapper.Map<TextPost>(entityDto);
        var result = await _textPostRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetTextPostDto?> GetAsync(Expression<Func<GetTextPostDto, bool>> filter)
    {
        var textPostFilter = _mapper.MapExpression<Expression<Func<TextPost, bool>>>(filter);
        var result = await _textPostRepository.GetAsync(textPostFilter);

        var getEntityDto = _mapper.Map<GetTextPostDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetTextPostDto>> GetListAsync(Expression<Func<GetTextPostDto, bool>>? filter = null)
    {
        var textPostFilter = _mapper.MapExpression<Expression<Func<TextPost, bool>>>(filter);
        var result = await _textPostRepository.GetListAsync(textPostFilter);

        var getEntityDtoList = _mapper.Map<List<GetTextPostDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetTextPostDto> UpdateAsync(UpdateTextPostDto entityDto)
    {
        var entity = _mapper.Map<TextPost>(entityDto);
        var result = await _textPostRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetTextPostDto>(result);
        return updatedEntityDto;
    }
}
