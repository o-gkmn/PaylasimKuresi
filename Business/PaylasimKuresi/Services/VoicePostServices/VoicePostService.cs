using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.VoicePostServices;
using DataAccess.Interfaces.VoicePostRepositories;
using Models.DTOs.VoicePostDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.VoicePostServices;

public class VoicePostService : IVoicePostService
{
    private readonly IVoicePostRepository _voicePostRepository;
    private readonly IMapper _mapper;

    public VoicePostService(IVoicePostRepository voicePostRepository, IMapper mapper)
    {
        _voicePostRepository = voicePostRepository;
        _mapper = mapper;
    }

    public async Task<GetVoicePostDto> CreateAsync(CreateVoicePostDto entityDto)
    {
        var entity = _mapper.Map<VoicePost>(entityDto);
        var result = await _voicePostRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetVoicePostDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetVoicePostDto entityDto)
    {
        var entity = _mapper.Map<VoicePost>(entityDto);
        var result = await _voicePostRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetVoicePostDto?> GetAsync(Expression<Func<GetVoicePostDto, bool>> filter)
    {
        var voicePostFilter = _mapper.MapExpression<Expression<Func<VoicePost, bool>>>(filter);
        var result = await _voicePostRepository.GetAsync(voicePostFilter);

        var getEntityDto = _mapper.Map<GetVoicePostDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetVoicePostDto>> GetListAsync(Expression<Func<GetVoicePostDto, bool>>? filter = null)
    {
        var voicePostFilter = _mapper.MapExpression<Expression<Func<VoicePost, bool>>>(filter);
        var result = await _voicePostRepository.GetListAsync(voicePostFilter);

        var getEntityDtoList = _mapper.Map<List<GetVoicePostDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetVoicePostDto> UpdateAsync(UpdateVoicePostDto entityDto)
    {
        var entity = _mapper.Map<VoicePost>(entityDto);
        var result = await _voicePostRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetVoicePostDto>(result);
        return updatedEntityDto;
    }
}
