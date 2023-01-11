using Bogus;
using iRenta.TestTask.Domain.Orders.Entities;
using iRenta.TestTask.Domain.Orders.Enumerations;
using System.Collections.Concurrent;

namespace iRenta.TestTask.Persistence.Data;

internal static class Orders
{
    internal static ConcurrentDictionary<short, Order> Data = new();

    static Orders()
    {
        sbyte number = 10;

        foreach (var order in new Faker<Order>()
            .RuleFor(o => o.Id, _ => Guid.NewGuid())
            .RuleFor(o => o.Number, _ => number++)
            .RuleFor(o => o.CustomerName, f => f.Person.FullName)
            .RuleFor(o => o.Status, (f, o) => f.PickRandom(OrderStatus.All.ToList()))
            .GenerateBetween(50, 100))
        {
            foreach (var item in new Faker<OrderItem>()
                .RuleFor(x => x.Id, _ => Guid.NewGuid())
                .RuleFor(x => x.Product, (f, x) => f.PickRandom(Products.Data.Values))
                .RuleFor(x => x.Count, f => (byte)f.Random.Int(1, 5))
                .GenerateBetween(2, 5))
            {
                order.AddItem(item);
            }

            Data.TryAdd(order.Number, order);
        }
    }
}
