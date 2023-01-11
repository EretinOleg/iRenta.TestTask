using CSharpFunctionalExtensions;
using iRenta.TestTask.Api.Contracts;
using iRenta.TestTask.Application.Products.Queries;
using iRenta.TestTask.Application.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using iRenta.TestTask.Application.Orders;
using iRenta.TestTask.Application.Orders.Queries;

namespace iRenta.TestTask.Api.Controllers;

public sealed class OrderController : ApiController
{
    public OrderController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Get all orders
    /// </summary>
    [HttpGet(ApiRoutes.Order.Get)]
    [ProducesResponseType(typeof(IReadOnlyCollection<OrderResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll() =>
        Ok(await Mediator.Send(new GetOrdersQuery()));

    /// <summary>
    /// Get order by its number
    /// </summary>
    [HttpGet(ApiRoutes.Order.GetByNumber)]
    [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCode(short number) =>
            (await Maybe<GetOrderByNumberQuery>
                .From(new GetOrderByNumberQuery(number))
                .Bind(async query => await Mediator.Send(query)))
            .Match<IActionResult, OrderResponse>(Ok, NotFound);

    
}
