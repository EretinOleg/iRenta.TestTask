using iRenta.TestTask.Domain.Orders.Entities;
using Mapster;

namespace iRenta.TestTask.Application.Orders;

internal class OrderMapperRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .ForType<Order, OrderResponse>();
    }
}
