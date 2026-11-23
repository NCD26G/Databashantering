using Core.Entities;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> ListAllAsync();
    Task<Product?> FindByIdAsync(int id);
}
