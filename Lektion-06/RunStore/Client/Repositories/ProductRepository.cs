using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Data;
using Client.Entities;
using Client.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Client.Repositories;

public class ProductRepository(RunStoreDbContext context) : IProductRepository
{
    private readonly RunStoreDbContext _context = context;

    public async Task<List<Product>> ListAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
}
