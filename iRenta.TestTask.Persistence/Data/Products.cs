using iRenta.TestTask.Domain.Orders.Entities;
using System.Collections.Concurrent;

namespace iRenta.TestTask.Persistence.Data;

internal static class Products
{
    internal static ConcurrentDictionary<sbyte, Product> Data = new();

    static Products()
    {
        Data.TryAdd(100, Product.Create(Guid.NewGuid(), 100, "Product 100", 10.0m).Value);
        Data.TryAdd(101, Product.Create(Guid.NewGuid(), 101, "Product 101", 12.0m).Value);
        Data.TryAdd(102, Product.Create(Guid.NewGuid(), 102, "Product 102", 1_000.0m).Value);
        Data.TryAdd(103, Product.Create(Guid.NewGuid(), 103, "Product 103", 50.0m).Value);
        Data.TryAdd(104, Product.Create(Guid.NewGuid(), 104, "Product 104", 1.55m).Value);
    }
}
