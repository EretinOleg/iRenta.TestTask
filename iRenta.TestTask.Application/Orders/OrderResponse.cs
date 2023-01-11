using iRenta.TestTask.Domain.Orders.Enumerations;

namespace iRenta.TestTask.Application.Orders;

public record OrderResponse(Guid Id, short Number, string CustomerName, OrderStatus Status, IReadOnlyCollection<OrderItemResponse> Items);
