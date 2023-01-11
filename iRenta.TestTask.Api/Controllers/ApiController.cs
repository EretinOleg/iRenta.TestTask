using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iRenta.TestTask.Api.Controllers;

/// <summary>
/// Base API controller
/// </summary>
[ApiController]
[Route("api/v1")]
public class ApiController : ControllerBase
{
    protected IMediator Mediator { get; init; }

    protected ApiController(IMediator mediator) => Mediator = mediator;
}

