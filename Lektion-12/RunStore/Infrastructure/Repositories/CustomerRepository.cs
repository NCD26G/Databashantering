using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository(RunStoreDbContext context) : ICustomerRepository
{
    public Task<Customer?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Customer>> ListAllAsync()
    {
        return await context.Customers
            .Include(c => c.Addresses)
            .ThenInclude(a => a.PostalCode)
            .ThenInclude(p => p.City)
            .ToListAsync();
    }
}
