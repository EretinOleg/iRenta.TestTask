using iRenta.TestTask.Application.Contracts.Messaging;

namespace iRenta.TestTask.Application.Orders.Queries;

public record GetOrdersQuery() : IQuery<IReadOnlyCollection<OrderResponse>>;
