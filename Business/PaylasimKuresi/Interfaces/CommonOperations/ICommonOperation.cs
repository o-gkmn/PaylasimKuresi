using System.Linq.Expressions;

namespace Business.PaylasimKuresi.Interfaces.CommonOperations;

public interface ICommonOperation<TCreate, TUpdate, TGet>
{
    Task<TGet?> GetAsync(Expression<Func<TGet, bool>> filter);
    Task<List<TGet>> GetListAsync(Expression<Func<TGet, bool>>? filter = null);
    Task<TCreate> CreateAsync(TCreate entityDto);
    Task<TUpdate> UpdateAsync(TUpdate entityDto);
    Task<bool> DeleteAsync(TGet entityDto);
}
