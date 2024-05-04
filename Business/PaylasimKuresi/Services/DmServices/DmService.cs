using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.DmServices;
using DataAccess.Interfaces.DmRepositories;
using Models.DTOs.DmDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.DmServices;

public class DmService : IDmService
{
    private readonly IDmRepository _dmRepository;
    private readonly IMapper _mapper;

    public DmService(IDmRepository dmRepository, IMapper mapper)
    {
        _dmRepository = dmRepository;
        _mapper = mapper;
    }

    public async Task<GetDmDto> CreateAsync(CreateDmDto entityDto)
    {
        var entity = _mapper.Map<Dm>(entityDto);
        var result = await _dmRepository.CreateAsync(entity);

        var createdEntityDto = _mapper.Map<GetDmDto>(result);
        return createdEntityDto;
    }

    public async Task<bool> DeleteAsync(GetDmDto entityDto)
    {
        var entity = _mapper.Map<Dm>(entityDto);
        var result = await _dmRepository.DeleteAsync(entity);

        return result;
    }

    public async Task<GetDmDto?> GetAsync(Expression<Func<GetDmDto, bool>> filter)
    {
        var dmFilter = _mapper.MapExpression<Expression<Func<Dm, bool>>>(filter);
        var result = await _dmRepository.GetAsync(dmFilter);

        var getEntityDto = _mapper.Map<GetDmDto>(result);
        return getEntityDto;
    }

    public async Task<List<GetDmDto>> GetListAsync(Expression<Func<GetDmDto, bool>>? filter = null)
    {
        var dmFilter = _mapper.MapExpression<Expression<Func<Dm, bool>>>(filter);
        var result = await _dmRepository.GetListAsync(dmFilter);

        var getEntityDtoList = _mapper.Map<List<GetDmDto>>(result);
        return getEntityDtoList;
    }

    public async Task<GetDmDto> UpdateAsync(UpdateDmDto entityDto)
    {
        var entity = _mapper.Map<Dm>(entityDto);
        var result = await _dmRepository.UpdateAsync(entity);

        var updatedEntityDto = _mapper.Map<GetDmDto>(result);
        return updatedEntityDto;
    }
}
