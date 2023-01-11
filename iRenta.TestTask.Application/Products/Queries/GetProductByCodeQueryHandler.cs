using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Domain.Contracts;
using Mapster;

namespace iRenta.TestTask.Application.Products.Queries;

public class GetProductByCodeQueryHandler : IQueryHandler<GetProductByCodeQuery, Maybe<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByCodeQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Maybe<ProductResponse>> Handle(GetProductByCodeQuery request, CancellationToken cancellationToken) =>
        Task.FromResult(
            Maybe.From(_productRepository.GetByCode(request.Code))
                .Map(x => x!.Adapt<ProductResponse>()));
}
