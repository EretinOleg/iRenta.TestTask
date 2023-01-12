using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Domain.Contracts;
using iRenta.TestTask.Domain.Core.Primitives;
using iRenta.TestTask.Domain.Orders.Entities;
using Mapster;

namespace iRenta.TestTask.Application.Orders.Commands;

public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand, Result<OrderResponse, Error>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public Task<Result<OrderResponse, Error>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _orderRepository.GetByNumber(request.Number);
        if (order is null)
            return Task.FromResult(Result.Failure<OrderResponse, Error>(Domain.Orders.Errors.Order.NotFound));

        // update customer name
        var updateResult = order.ChangeCustomerName(request.CustomerName);
        if (updateResult.IsFailure)
            return Task.FromResult(Result.Failure<OrderResponse, Error>(updateResult.Error));

        // update order items
        // remove absent items
        foreach (var absent in order.Items.Where(x => request.Items.All(i => i.ProductCode != x.Product.VendorCode)).ToList())
            order.RemoveItem(absent);
        foreach (var group in request.Items.GroupBy(x => x.ProductCode))
        {
            var product = _productRepository.GetByCode(group.Key);
            if (product is null)
                return Task.FromResult(Result.Failure<OrderResponse, Error>(Domain.Orders.Errors.Product.NotFound));

            var item = order.Items.FirstOrDefault(x => x.Product.VendorCode == group.Key);
            // add new item
            if (item is null)
            {
                var itemResult = OrderItem.Create(Guid.NewGuid(), product!, (byte)group.Sum(x => x.Count));
                if (itemResult.IsFailure)
                    return Task.FromResult(Result.Failure<OrderResponse, Error>(itemResult.Error));

                var addResult = order.AddItem(itemResult.Value);
                if (addResult.IsFailure)
                    return Task.FromResult(Result.Failure<OrderResponse, Error>(addResult.Error));
            }
            // update count for existing items
            else
            {
                var result = order.ChangeCount(item, (byte)group.Sum(x => x.Count));
                if (result.IsFailure)
                    return Task.FromResult(Result.Failure<OrderResponse, Error>(result.Error));
            }
        }

        // TODO: here should be unit of work to commit/rollback changes
        return Task.FromResult(
            Result.Success<OrderResponse, Error>(_orderRepository.GetByNumber(request.Number)!.Adapt<OrderResponse>()));
    }
}
