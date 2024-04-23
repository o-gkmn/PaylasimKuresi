using System.Linq.Expressions;

namespace DataAccess.Interfaces.CommonOperations;

public interface ICommonOperations<T> where T : class
{
    Task<T?> GetAsync(Expression<Func<T, bool>> filter);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>>? filter = null);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
}
