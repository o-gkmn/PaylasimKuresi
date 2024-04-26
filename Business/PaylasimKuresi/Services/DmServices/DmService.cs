using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.DmServices;
using DataAccess.Interfaces.DmRepositories;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.DmServices;

public class DmService : IDmService
{
    private readonly IDmRepository _dmRepository;

    public DmService(IDmRepository dmRepository)
    {
        _dmRepository = dmRepository;
    }

    public async Task<Dm> CreateAsync(Dm entity)
    {
        var result = await _dmRepository.CreateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(Dm entity)
    {
        var result = await _dmRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<Dm?> GetAsync(Expression<Func<Dm, bool>> filter)
    {
        var result = await _dmRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<Dm>> GetListAsync(Expression<Func<Dm, bool>>? filter = null)
    {
        var result = await _dmRepository.GetListAsync(filter);
        return result;
    }

    public async Task<Dm> UpdateAsync(Dm entity)
    {
        var result = await _dmRepository.UpdateAsync(entity);
        return result;
    }
}
