using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Domain.Contracts;
using iRenta.TestTask.Domain.Core.Primitives;
using iRenta.TestTask.Domain.Orders.Enumerations;

namespace iRenta.TestTask.Application.Orders.Commands;

public class RemoveOrderCommandHandler : ICommandHandler<RemoveOrderCommand, UnitResult<Error>>
{
    private readonly IOrderRepository _orderRepository;

    public RemoveOrderCommandHandler(IOrderRepository orderRepository) 
    { 
        _orderRepository = orderRepository; 
    }

    public Task<UnitResult<Error>> Handle(RemoveOrderCommand request, CancellationToken cancellationToken) =>
        Task.FromResult(
            Maybe.From(_orderRepository.GetByNumber(request.Number))
                .ToResult(Domain.Orders.Errors.Order.NotFound)
                .Ensure(o => o!.Status == OrderStatus.Registered, _ => Domain.Orders.Errors.Order.InvalidStatus)
                .Tap(x => _orderRepository.Remove(x!))
                .Match(_ => UnitResult.Success<Error>(), e => UnitResult.Failure(e)));
}
