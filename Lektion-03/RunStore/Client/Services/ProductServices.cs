using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Npgsql;

namespace Client.Services;

public class ProductServices : BaseService, IProductService
{
    public async Task Add(Product product)
    {

    }

    public async Task Delete(string id)
    {

    }

    public Task<Product> Find(string itemNumber)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> List()
    {
        try
        {
            List<Product> products = [];
            // Hämta data ifrån Postgres
            // 1. Skapa ett anslutningsobjekt
            using NpgsqlConnection connection = new(ConnectionString);
            // 2. Skapa ett fråge objekt
            using NpgsqlCommand command = connection.CreateCommand();
            // 3. Lägg till sql frågan till frågeobjektet
            command.CommandText = @"SELECT
                                        products.id,
                                        itemnumber,
                                        productname,
                                        price,
                                        suppliername
                                    FROM products INNER JOIN suppliers
                                        ON products.supplier_id = suppliers.id";

            // 4. Öppna nu anslutningen till databasen => neon.com...
            await connection.OpenAsync();

            // Kör frågan...
            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            // Iterar igenom resultatet...
            while (await reader.ReadAsync())
            {
                products.Add(new Product
                {
                    Id = reader.GetInt32(0),
                    ItemNumber = reader.GetString(1),
                    Name = reader.GetString(2),
                    Price = (int)reader.GetFloat(3),
                    SupplierName = reader.GetString(4)
                });
            }

            return products;
        }
        catch (InvalidOperationException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public async Task Update(Product product, string _objectId)
    {

    }
}
