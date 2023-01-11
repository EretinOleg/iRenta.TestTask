using CSharpFunctionalExtensions;
using iRenta.TestTask.Domain.Core.Primitives;

namespace iRenta.TestTask.Domain.Orders.Entities;

public class Product : Core.Primitives.Entity
{
    public sbyte VendorCode { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    private Product(Guid id, sbyte vendorCode, string name, decimal price)
        : base(id)
    {
        VendorCode = vendorCode;
        Name = name;
        Price = price;
    }

    public static Result<Product, Error> Create(Guid id, sbyte vendorCode, string name, decimal price) =>
        Result.Success<bool, Error>(true)
            .Ensure(_ => !string.IsNullOrWhiteSpace(name), _ => Errors.Product.NameIsNullOrEmpty)
            .Ensure(_ => !decimal.IsNegative(price), _ => Errors.Product.NegativePrice)
            .Map(_ => new Product(id, vendorCode, name.Trim(), price));
}
