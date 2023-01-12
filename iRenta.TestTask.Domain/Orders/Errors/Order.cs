using iRenta.TestTask.Domain.Core.Primitives;

namespace iRenta.TestTask.Domain.Orders.Errors;

public static class Order
{
    public static Error NotFound => new Error("Order.NotFound", "Order with specified number not found.");

    public static Error InvalidStatus => new Error("Order.InvalidStatus", "Order is in invalid status.");

    public static Error StatusIsEmpty => new Error("Order.StatusIsEmpty", "Order status not specified.");

    public static Error DuplicateNumber => new Error("Order.DuplicateNumber", "The order with specified number already exists.");

    public static Error TooManyItems => new Error("Order.TooManyItems", $"Order cannot contains more than {Entities.Order.MaxItemsCount} items.");

    public static Error TotalSumExceeded => new Error("Order.TotalSumExceeded", $"Order sum cannot be more than {Entities.Order.MaxSum:F2}.");
}
