using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.ImagePostServices;
using DataAccess.Interfaces.ImagePostRepositories;
using Models.DTOs.ImagePostDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.ImagePostServices;

public class ImagePostService : IImagePostService
{
    private readonly IImagePostRepository _imagePostRepository;
    private readonly IMapper _mapper;

    public ImagePostService(IImagePostRepository imagePostRepository, IMapper mapper)
    {
        _imagePostRepository = imagePostRepository;
        _mapper = mapper;
    }

    public async Task<GetImagePostDto> CreateAsync(CreateImagePostDto entityDto)
    {
        var entity = _mapper.Map<ImagePost>(entityDto);
        var result = await _imagePostRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetImagePostDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetImagePostDto entityDto)
    {
        var entity = _mapper.Map<ImagePost>(entityDto);
        var result = await _imagePostRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetImagePostDto?> GetAsync(Expression<Func<GetImagePostDto, bool>> filter)
    {
        var imagePostFilter = _mapper.MapExpression<Expression<Func<ImagePost, bool>>>(filter);
        var result = await _imagePostRepository.GetAsync(imagePostFilter);

        var getEntityDto = _mapper.Map<GetImagePostDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetImagePostDto>> GetListAsync(Expression<Func<GetImagePostDto, bool>>? filter = null)
    {
        var imagePostFilter = _mapper.MapExpression<Expression<Func<ImagePost, bool>>>(filter);
        var result = await _imagePostRepository.GetListAsync(imagePostFilter);

        var getEntityDtoList = _mapper.Map<List<GetImagePostDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetImagePostDto> UpdateAsync(UpdateImagePostDto entityDto)
    {
        var entity = _mapper.Map<ImagePost>(entityDto);
        var result = await _imagePostRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetImagePostDto>(result);
        return updatedEntityDto;
    }
}
