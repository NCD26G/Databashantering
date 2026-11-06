using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Npgsql;

namespace Client.Services;

public class SupplierServices<T> : BaseService, ISupplierService<Supplier>
{
    public Task Add(Supplier data)
    {
        throw new System.NotImplementedException();
    }

    public Task Delete(Supplier data)
    {
        throw new System.NotImplementedException();
    }

    public Task<Supplier> FindById(int id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<Supplier>> ListAll()
    {
        try
        {
            List<Supplier> suppliers = [];
            // Hämta data ifrån Postgres
            // 1. Skapa ett anslutningsobjekt
            using NpgsqlConnection connection = new(ConnectionString);
            // 2. Skapa ett fråge objekt
            using NpgsqlCommand command = connection.CreateCommand();
            // 3. Lägg till sql frågan till frågeobjektet
            command.CommandText = @"SELECT
                                        id,
                                        suppliername
                                    FROM suppliers";

            // 4. Öppna nu anslutningen till databasen => neon.com...
            await connection.OpenAsync();
            // Kör frågan...
            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            // Iterar igenom resultatet...
            while (await reader.ReadAsync())
            {
                suppliers.Add(new Supplier()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            return suppliers;
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

    public Task Update(Supplier data)
    {
        throw new System.NotImplementedException();
    }
}
