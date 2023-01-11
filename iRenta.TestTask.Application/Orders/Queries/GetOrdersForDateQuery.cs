using iRenta.TestTask.Application.Contracts.Messaging;

namespace iRenta.TestTask.Application.Orders.Queries;

public record GetOrdersForDateQuery(DateOnly Date) : IQuery<IReadOnlyCollection<OrderResponse>>;
