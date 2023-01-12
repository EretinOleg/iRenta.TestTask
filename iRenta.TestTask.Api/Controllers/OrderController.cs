using CSharpFunctionalExtensions;
using iRenta.TestTask.Api.Contracts;
using iRenta.TestTask.Application.Orders;
using iRenta.TestTask.Application.Orders.Commands;
using iRenta.TestTask.Application.Orders.Queries;
using iRenta.TestTask.Domain.Core.Extensions;
using iRenta.TestTask.Domain.Core.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    /// <summary>
    /// Get orders for date
    /// </summary>
    [HttpGet(ApiRoutes.Order.GetForDate)]
    [ProducesResponseType(typeof(IReadOnlyCollection<OrderResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetForDate(string date) =>
        Ok(await Mediator.Send(new GetOrdersForDateQuery(DateOnly.Parse(date))));

    /// <summary>
    /// Remove order
    /// </summary>
    [HttpDelete(ApiRoutes.Order.Remove)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Remove([FromRoute] short number) =>
        (await Result.Success<RemoveOrderCommand, Error>(new RemoveOrderCommand(number))
            .Bind(async x => await Mediator.Send(x)))
            .Match<IActionResult, Error>(Ok, BadRequest);
}
