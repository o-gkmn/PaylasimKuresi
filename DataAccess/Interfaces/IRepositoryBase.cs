namespace DataAccess.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T?> GetByIdAsync(string id);
    Task<List<T>> GetAllAsync();
}