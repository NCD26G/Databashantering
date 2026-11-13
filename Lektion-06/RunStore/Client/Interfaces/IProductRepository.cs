using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Entities;

namespace Client.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> ListAllAsync();
}
