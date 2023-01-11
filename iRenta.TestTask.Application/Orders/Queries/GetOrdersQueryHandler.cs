using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Domain.Contracts;
using Mapster;

namespace iRenta.TestTask.Application.Orders.Queries;

public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, IReadOnlyCollection<OrderResponse>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<IReadOnlyCollection<OrderResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken) =>
        Task.FromResult(_orderRepository.GetAll()
            .Adapt<IReadOnlyCollection<OrderResponse>>());
}
