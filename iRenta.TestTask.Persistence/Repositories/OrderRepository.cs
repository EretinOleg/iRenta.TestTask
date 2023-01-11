using iRenta.TestTask.Domain.Contracts;
using iRenta.TestTask.Domain.Orders.Entities;
using iRenta.TestTask.Domain.Orders.Enumerations;
using iRenta.TestTask.Persistence.Data;
using System.Collections.Concurrent;

namespace iRenta.TestTask.Persistence.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    protected override IEnumerable<Order> DataSource => Orders.Data.Values;


    public IEnumerable<Order> GetAll() => DataSource;

    public Order? GetByNumber(short number) => DataSource.FirstOrDefault(x => x.Number == number);

    public IEnumerable<Order> GetForDate(DateOnly date) => DataSource.Where(x => x.RegisteredDate == date).ToList();

    public IEnumerable<Order> GetByStatus(OrderStatus status) => DataSource.Where(o => o.Status == status).ToList();

    public void Insert(Order entity) =>
        Orders.Data.TryAdd(entity.Number, entity);

    public void Remove(Order entity) =>
        Orders.Data.TryRemove(entity.Number, out _);
}
