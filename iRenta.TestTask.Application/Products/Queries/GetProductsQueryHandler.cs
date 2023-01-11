using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Domain.Contracts;
using Mapster;

namespace iRenta.TestTask.Application.Products.Queries;

public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IReadOnlyCollection<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository) 
    { 
        _productRepository = productRepository; 
    }

    public Task<IReadOnlyCollection<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken) =>
        Task.FromResult(_productRepository.GetAll()
            .Adapt<IReadOnlyCollection<ProductResponse>>());
}
