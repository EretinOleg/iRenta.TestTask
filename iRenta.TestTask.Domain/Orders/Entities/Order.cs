using CSharpFunctionalExtensions;
using iRenta.TestTask.Domain.Core.Primitives;
using iRenta.TestTask.Domain.Orders.Enumerations;

namespace iRenta.TestTask.Domain.Orders.Entities;

public class Order : Core.Primitives.Entity
{
    public short Number { get; private set; }
    public string CustomerName { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateOnly RegisteredDate { get; private set; }

    private List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    // for test data only
    public Order() { }

    private Order(Guid id, short number, string customerName, OrderStatus status, DateOnly registeredDate)
        : base(id)
    {
        Number = number;
        CustomerName = customerName;
        Status = status;
        RegisteredDate = registeredDate;
    }

    public static Result<Order, Error> Create(Guid id, short number, string customerName, OrderStatus status, DateOnly registeredDate) =>
        Result.Success<bool, Error>(true)
            // TODO: number is unique
            .Map(_ => new Order(id, number, customerName, status, registeredDate));

    public void AddItem(OrderItem item)
    {
        _items.Add(item);
    }
}
