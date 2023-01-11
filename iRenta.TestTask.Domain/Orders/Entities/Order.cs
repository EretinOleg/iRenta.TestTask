using CSharpFunctionalExtensions;
using iRenta.TestTask.Domain.Core.Primitives;
using iRenta.TestTask.Domain.Orders.Enumerations;

namespace iRenta.TestTask.Domain.Orders.Entities;

public class Order : Core.Primitives.Entity
{
    public short Number { get; private set; }
    public string CustomerName { get; private set; }
    public OrderStatus Status { get; private set; }

    private List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    private Order(Guid id, short number, string customerName, OrderStatus status)
        : base(id)
    {
        Number = number;
        CustomerName = customerName;
        Status = status;
    }

    public static Result<Order, Error> Create(Guid id, short number, string customerName, OrderStatus status) =>
        Result.Success<bool, Error>(true)
            // TODO: number is unique
            .Map(_ => new Order(id, number, customerName, status));
}
