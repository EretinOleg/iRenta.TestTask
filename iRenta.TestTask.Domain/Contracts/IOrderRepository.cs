using iRenta.TestTask.Domain.Orders.Entities;

namespace iRenta.TestTask.Domain.Contracts;

/// <summary>
/// Order repository
/// </summary>
public interface IOrderRepository
{
    Order? GetByNumber(short number);

    IEnumerable<Order> GetAll();

    void Insert(Order entity);

    void Remove(Order entity);
}
