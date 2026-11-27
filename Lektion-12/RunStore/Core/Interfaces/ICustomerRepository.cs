using Core.Entities;

namespace Core.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> FindByIdAsync(int id);
    Task<IReadOnlyList<Customer>> ListAllAsync();
}
