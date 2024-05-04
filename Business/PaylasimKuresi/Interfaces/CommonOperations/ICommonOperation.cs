using System.Linq.Expressions;

namespace Business.PaylasimKuresi.Interfaces.CommonOperations;

public interface ICommonOperation<TCreate, TUpdate, TGet>
{
    Task<TGet?> GetAsync(Expression<Func<TGet, bool>> filter);
    Task<List<TGet>> GetListAsync(Expression<Func<TGet, bool>>? filter = null);
    Task<TCreate> CreateAsync(TCreate entity);
    Task<TUpdate> UpdateAsync(TUpdate entity);
    Task<bool> DeleteAsync(TGet entity);
}
