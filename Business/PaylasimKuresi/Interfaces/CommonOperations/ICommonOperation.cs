using System.Linq.Expressions;

namespace Business.PaylasimKuresi.Interfaces.CommonOperations;

public interface ICommonOperation<TCreate, TUpdate, TGet>
{
    Task<TGet?> GetAsync(Expression<Func<TGet, bool>> filter);
    Task<List<TGet>> GetListAsync(Expression<Func<TGet, bool>>? filter = null);
    Task<TGet> CreateAsync(TCreate entityDto);
    Task<TGet> UpdateAsync(TUpdate entityDto);
    Task<bool> DeleteAsync(TGet entityDto);
}
