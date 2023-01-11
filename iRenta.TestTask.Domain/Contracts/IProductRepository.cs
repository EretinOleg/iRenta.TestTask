using iRenta.TestTask.Domain.Orders.Entities;

namespace iRenta.TestTask.Domain.Contracts;

public interface IProductRepository
{
    Product? GetByCode(sbyte code);

    IEnumerable<Product> GetAll();
}
