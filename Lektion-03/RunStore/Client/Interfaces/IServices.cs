using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Interfaces;

public interface IServices<T> where T : class
{
    Task Add(T data);
    Task<T> FindById(int id);
    Task<List<T>> ListAll();
    Task Delete(T data);
    Task Update(T data);
}
