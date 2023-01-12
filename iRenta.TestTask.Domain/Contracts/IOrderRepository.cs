using iRenta.TestTask.Domain.Orders.Entities;
using iRenta.TestTask.Domain.Orders.Enumerations;

namespace iRenta.TestTask.Domain.Contracts;

/// <summary>
/// Order repository
/// </summary>
public interface IOrderRepository
{
    Order? GetByNumber(short number);

    IEnumerable<Order> GetAll();

    IEnumerable<Order> GetForDate(DateOnly date);

    public IEnumerable<Order> GetByStatus(OrderStatus status);

    bool IsNumberExist(Guid id, short number);

    void Insert(Order entity);

    void Remove(Order entity);
}
