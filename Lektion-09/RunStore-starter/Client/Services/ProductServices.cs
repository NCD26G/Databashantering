using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class ProductServices<T> : BaseService, IProductService<Product> where T : class
{
    public Task<bool> Add(Product data)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Product data)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Find(string search)
    {
        throw new NotImplementedException();
    }

    public Task<Product> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> ListAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(Product data)
    {
        throw new NotImplementedException();
    }
}
