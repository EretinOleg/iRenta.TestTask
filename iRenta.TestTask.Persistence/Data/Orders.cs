using iRenta.TestTask.Domain.Orders.Entities;
using iRenta.TestTask.Domain.Orders.Enumerations;
using System.Collections.Concurrent;

namespace iRenta.TestTask.Persistence.Data;

internal static class Orders
{
    internal static ConcurrentDictionary<short, Order> Data = new();

    static Orders()
    {
        Data.TryAdd(10, Order.Create(Guid.NewGuid(), 10, "John Smith", OrderStatus.Registered).Value);
        Data.TryAdd(11, Order.Create(Guid.NewGuid(), 11, "Ivan Ivanov", OrderStatus.Registered).Value);
        Data.TryAdd(12, Order.Create(Guid.NewGuid(), 12, "James", OrderStatus.Canceled).Value);
        Data.TryAdd(13, Order.Create(Guid.NewGuid(), 13, "Victor", OrderStatus.Completed).Value);
        Data.TryAdd(14, Order.Create(Guid.NewGuid(), 14, "Michael B.", OrderStatus.Registered).Value);
        Data.TryAdd(15, Order.Create(Guid.NewGuid(), 15, "Leo Messi", OrderStatus.Registered).Value);
    }
}
