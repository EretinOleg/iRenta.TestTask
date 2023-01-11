using iRenta.TestTask.Domain.Contracts;
using iRenta.TestTask.Domain.Orders.Entities;
using iRenta.TestTask.Persistence.Data;

namespace iRenta.TestTask.Persistence.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    protected override IEnumerable<Product> DataSource => Products.Data.Values;


    public IEnumerable<Product> GetAll() => DataSource;

    public Product? GetByCode(sbyte code) => DataSource.FirstOrDefault(p => p.VendorCode == code);
}
