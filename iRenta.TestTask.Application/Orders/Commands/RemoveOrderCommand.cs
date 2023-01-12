using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Domain.Core.Primitives;

namespace iRenta.TestTask.Application.Orders.Commands;

public record RemoveOrderCommand(short Number) : ICommand<UnitResult<Error>>;
