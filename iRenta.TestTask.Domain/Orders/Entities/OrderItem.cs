using CSharpFunctionalExtensions;
using iRenta.TestTask.Domain.Core.Primitives;

namespace iRenta.TestTask.Domain.Orders.Entities;

public class OrderItem : Core.Primitives.Entity
{
    public Product Product { get; private set; }
    public byte Count { get; private set; }

    // for test data only
    public OrderItem() { }

    private OrderItem(Guid id, Product product, byte count)
        : base(id)
    {
        Product = product;
        Count = count;
    }

    public static Result<OrderItem, Error> Create(Guid id, Product product, byte count) =>
        Result.Success<bool, Error>(true)
            .Ensure(_ => product is not null, _ => Errors.OrderItem.ProductIsNull)
            .Ensure(_ => count > 0, _ => Errors.OrderItem.InvalidCount)
            .Map(_ => new OrderItem(id, product, count));
}
