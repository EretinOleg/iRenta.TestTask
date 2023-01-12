using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Domain.Contracts;
using iRenta.TestTask.Domain.Core.Primitives;
using iRenta.TestTask.Domain.Orders.Entities;
using iRenta.TestTask.Domain.Orders.Enumerations;
using Mapster;

namespace iRenta.TestTask.Application.Orders.Commands;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Result<OrderResponse, Error>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public Task<Result<OrderResponse, Error>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Items.GroupBy(x => x.ProductCode).Count() > Order.MaxItemsCount)
            return Task.FromResult(Result.Failure<OrderResponse, Error>(Domain.Orders.Errors.Order.TooManyItems));

        var result = Order.Create(Guid.NewGuid(), request.Number, request.CustomerName,
            OrderStatus.Registered, DateOnly.FromDateTime(DateTime.UtcNow), _orderRepository);
        if (result.IsFailure)
            return Task.FromResult(Result.Failure<OrderResponse, Error>(result.Error));

        var order = result.Value;
        foreach(var group in request.Items.GroupBy(x => x.ProductCode))
        {
            var product = _productRepository.GetByCode(group.Key);
            if (product is null)
                return Task.FromResult(Result.Failure<OrderResponse, Error>(Domain.Orders.Errors.Product.NotFound));

            var itemResult = OrderItem.Create(Guid.NewGuid(), product!, (byte)group.Sum(x => x.Count));
            if (itemResult.IsFailure)
                return Task.FromResult(Result.Failure<OrderResponse, Error>(itemResult.Error));

            var addResult = order.AddItem(itemResult.Value);
            if (addResult.IsFailure)
                return Task.FromResult(Result.Failure<OrderResponse, Error>(addResult.Error));
        }

        _orderRepository.Insert(order);
        return Task.FromResult(
            Result.Success<OrderResponse, Error>(_orderRepository.GetByNumber(request.Number)!.Adapt<OrderResponse>()));
    }
}
