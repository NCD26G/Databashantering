using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository(RunStoreDbContext context) : IProductRepository
{
    public async Task<Product?> FindByIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public Task<IReadOnlyList<Product>> FindByNameAsync(string searchValue)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Product>> ListAllAsync()
    {
        return await context.Products.Include(c => c.Supplier).ToListAsync();
    }
}
