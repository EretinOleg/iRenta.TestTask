using CSharpFunctionalExtensions;
using iRenta.TestTask.Domain.Contracts;
using iRenta.TestTask.Domain.Core.Primitives;
using iRenta.TestTask.Domain.Orders.Enumerations;

namespace iRenta.TestTask.Domain.Orders.Entities;

public class Order : Core.Primitives.Entity
{
    public const int MaxItemsCount = 10;
    public const decimal MaxSum = 15_000m;

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

    public static Result<Order, Error> Create(Guid id, short number, string customerName, OrderStatus status, DateOnly registeredDate,
        IOrderRepository orderRepository) =>
        Result.Success<bool, Error>(true)
            .Ensure(_ => status is not null, _ => Errors.Order.StatusIsEmpty)
            .Ensure(_ => !orderRepository.IsNumberExist(id, number), _ => Errors.Order.DuplicateNumber)
            .Map(_ => new Order(id, number, customerName, status, registeredDate));

    public UnitResult<Error> AddItem(OrderItem item) =>
        UnitResult.Success<Error>()
            .Ensure(() => _items.Count() < MaxItemsCount, () => Errors.Order.TooManyItems)
            .Ensure(() => _items.Sum(x => x.Product.Price * x.Count) + item.Product.Price * item.Count < MaxSum, () => Errors.Order.TotalSumExceeded)
            .Tap(() => _items.Add(item));
}
