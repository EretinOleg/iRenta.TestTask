using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Domain.Contracts;
using iRenta.TestTask.Domain.Core.Primitives;
using Mapster;

namespace iRenta.TestTask.Application.Orders.Commands;

public class PatchOrderCommandHandler : ICommandHandler<PatchOrderCommand, Result<OrderResponse, Error>>
{
    private readonly IOrderRepository _orderRepository;

    public PatchOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<Result<OrderResponse, Error>> Handle(PatchOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _orderRepository.GetByNumber(request.Number);
        if (order is null)
            return Task.FromResult(Result.Failure<OrderResponse, Error>(Domain.Orders.Errors.Order.NotFound));

        // TODO: complete this
        request.Request.ApplyTo(order);

        // TODO: here should be unit of work to commit/rollback changes
        return Task.FromResult(
            Result.Success<OrderResponse, Error>(_orderRepository.GetByNumber(request.Number)!.Adapt<OrderResponse>()));
    }
}
