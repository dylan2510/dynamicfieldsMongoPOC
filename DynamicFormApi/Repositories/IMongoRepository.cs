namespace DynamicFormApi.Repositories;

public interface IMongoRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(string id);
    Task CreateAsync(T entity);
    Task UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
}
