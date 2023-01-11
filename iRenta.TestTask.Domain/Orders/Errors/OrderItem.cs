using iRenta.TestTask.Domain.Core.Primitives;

namespace iRenta.TestTask.Domain.Orders.Errors;

public static class OrderItem
{
    public static Error ProductIsNull => new Error("OrderItem.ProductIsNull", "Product cannot be null.");

    public static Error InvalidCount => new Error("OrderItem.InvalidCount", "Order item count should be positive integer.");
}
