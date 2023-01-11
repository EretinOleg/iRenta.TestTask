using Bogus;
using iRenta.TestTask.Domain.Orders.Entities;
using System.Collections.Concurrent;

namespace iRenta.TestTask.Persistence.Data;

internal static class Products
{
    internal static ConcurrentDictionary<sbyte, Product> Data = new();

    static Products()
    {
        sbyte code = 100;

        foreach(var product in new Faker<Product>()
            .RuleFor(p => p.Id, _ => Guid.NewGuid())
            .RuleFor(p => p.VendorCode, _ => code++)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(1.0m, 100.0m)))
            .GenerateBetween(10, 20))
        {
            Data.TryAdd(product.VendorCode, product);
        }
    }
}
