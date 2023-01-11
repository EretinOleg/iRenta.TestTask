using iRenta.TestTask.Domain.Orders.Entities;
using Mapster;

namespace iRenta.TestTask.Application.Orders;

internal class OrderItemMapperRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .ForType<OrderItem, OrderItemResponse>();
    }
}
