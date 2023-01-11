using iRenta.TestTask.Domain.Orders.Entities;
using Mapster;

namespace iRenta.TestTask.Application.Products;

internal sealed class ProductMapperRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .ForType<Product, ProductResponse>();
    }
}
