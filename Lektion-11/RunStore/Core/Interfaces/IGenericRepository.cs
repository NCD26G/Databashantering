using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    void Add(T entity);
    void Delete(T entity);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T?> FindByIdAsync(int id);
    void Update(T entity);
    Task<bool> SaveAllAsync();
}
