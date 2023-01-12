using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Domain.Core.Primitives;
using Microsoft.AspNetCore.JsonPatch;

namespace iRenta.TestTask.Application.Orders.Commands;

public record PatchOrderCommand(short Number, JsonPatchDocument Request) : ICommand<Result<OrderResponse, Error>>;
