using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.VideoPostServices;
using DataAccess.Interfaces.VideoPostRepositories;
using Models.DTOs.VideoPostDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.VideoPostServices;

public class VideoPostService : IVideoPostService
{
    private readonly IVideoPostRepository _videoPostRepository;
    private readonly IMapper _mapper;

    public VideoPostService(IVideoPostRepository videoPostRepository, IMapper mapper)
    {
        _videoPostRepository = videoPostRepository;
        _mapper = mapper;
    }

    public async Task<GetVideoPostDto> CreateAsync(CreateVideoPostDto entityDto)
    {
        var entity = _mapper.Map<VideoPost>(entityDto);
        var result = await _videoPostRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetVideoPostDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetVideoPostDto entityDto)
    {
        var entity = _mapper.Map<VideoPost>(entityDto);
        var result = await _videoPostRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetVideoPostDto?> GetAsync(Expression<Func<GetVideoPostDto, bool>> filter)
    {
        var videoPostFilter = _mapper.MapExpression<Expression<Func<VideoPost, bool>>>(filter);
        var result = await _videoPostRepository.GetAsync(videoPostFilter);

        var getEntityDto = _mapper.Map<GetVideoPostDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetVideoPostDto>> GetListAsync(Expression<Func<GetVideoPostDto, bool>>? filter = null)
    {
        var videoPostFilter = _mapper.MapExpression<Expression<Func<VideoPost, bool>>>(filter);
        var result = await _videoPostRepository.GetListAsync(videoPostFilter);

        var getEntityDtoList = _mapper.Map<List<GetVideoPostDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetVideoPostDto> UpdateAsync(UpdateVideoPostDto entityDto)
    {
        var entity = _mapper.Map<VideoPost>(entityDto);
        var result = await _videoPostRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetVideoPostDto>(result);
        return updatedEntityDto;
    }
}
