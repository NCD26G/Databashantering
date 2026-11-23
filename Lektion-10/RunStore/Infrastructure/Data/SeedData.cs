using System.Text.Encodings.Web;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class SeedData
{
    public static void AddData(RunStoreDbContext context)
    {
        var jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        if (!context.Suppliers.Any())
        {
            var supplierData = File.ReadAllText("../Infrastructure/Data/TestData/suppliers.json");
            var suppliers = JsonSerializer.Deserialize<List<Supplier>>(supplierData, jsonOptions);

            if (suppliers is null) return;

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }

        if (!context.Products.Any())
        {
            var productData = File.ReadAllText("../Infrastructure/Data/TestData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productData, jsonOptions);

            if (products is null) return;

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
