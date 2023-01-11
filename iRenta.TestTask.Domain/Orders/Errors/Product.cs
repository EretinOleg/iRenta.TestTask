using iRenta.TestTask.Domain.Core.Primitives;

namespace iRenta.TestTask.Domain.Orders.Errors;

public static class Product
{
    public static Error NameIsNullOrEmpty => new Error("Product.NameIsNullOrEmpty", "Product name cannot be empty");

    public static Error NegativePrice => new Error("Product.NegativePrice", "Product price cannot be negative");
}
