using CSharpFunctionalExtensions;
using iRenta.TestTask.Api.Contracts;
using iRenta.TestTask.Application.Products;
using iRenta.TestTask.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iRenta.TestTask.Api.Controllers;

public sealed class ProductController : ApiController
{
    public ProductController(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// Get product by its code
    /// </summary>
    [HttpGet(ApiRoutes.Product.GetByCode)]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCode(sbyte code) =>
            (await Maybe<GetProductByCodeQuery>
                .From(new GetProductByCodeQuery(code))
                .Bind(async query => await Mediator.Send(query)))
            .Match<IActionResult, ProductResponse>(Ok, NotFound);

    /// <summary>
    /// Get all products
    /// </summary>
    [HttpGet(ApiRoutes.Product.Get)]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProductResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll() =>
        Ok(await Mediator.Send(new GetProductsQuery()));
}
