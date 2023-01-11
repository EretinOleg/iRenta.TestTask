using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Domain.Contracts;
using Mapster;

namespace iRenta.TestTask.Application.Orders.Queries;

public class GetOrdersForDateQueryHandler : IQueryHandler<GetOrdersForDateQuery, IReadOnlyCollection<OrderResponse>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersForDateQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<IReadOnlyCollection<OrderResponse>> Handle(GetOrdersForDateQuery request, CancellationToken cancellationToken) =>
        Task.FromResult(_orderRepository.GetForDate(request.Date)
            .Adapt<IReadOnlyCollection<OrderResponse>>());
}
