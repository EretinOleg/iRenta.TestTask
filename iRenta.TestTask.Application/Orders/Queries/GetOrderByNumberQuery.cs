using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Application.Products;

namespace iRenta.TestTask.Application.Orders.Queries
{
    public record GetOrderByNumberQuery(short Number) : IQuery<Maybe<OrderResponse>>;
}
