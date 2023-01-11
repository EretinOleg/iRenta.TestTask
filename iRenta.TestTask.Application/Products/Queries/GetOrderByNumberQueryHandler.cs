using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Application.Orders;
using iRenta.TestTask.Application.Orders.Queries;
using iRenta.TestTask.Domain.Contracts;
using Mapster;

namespace iRenta.TestTask.Application.Products.Queries;

public class GetOrderByNumberQueryHandler : IQueryHandler<GetOrderByNumberQuery, Maybe<OrderResponse>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByNumberQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<Maybe<OrderResponse>> Handle(GetOrderByNumberQuery request, CancellationToken cancellationToken) =>
        Task.FromResult(
            Maybe.From(_orderRepository.GetByNumber(request.Number))
                .Map(x => x!.Adapt<OrderResponse>()));
    
}
