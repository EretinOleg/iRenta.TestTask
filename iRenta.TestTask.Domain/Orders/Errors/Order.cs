using iRenta.TestTask.Domain.Core.Primitives;

namespace iRenta.TestTask.Domain.Orders.Errors;

public static class Order
{
    public static Error NotFound => new Error("Order.NotFound", "Order with specified number not found.");
}
