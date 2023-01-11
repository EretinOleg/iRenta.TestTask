using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;

namespace iRenta.TestTask.Application.Orders.Queries;

public record GetOrderByNumberQuery(short Number) : IQuery<Maybe<OrderResponse>>;
