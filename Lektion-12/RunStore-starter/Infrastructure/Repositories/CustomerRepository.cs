using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public Task<Customer?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Customer>> ListAllAsync()
    {
        throw new NotImplementedException();
    }
}
