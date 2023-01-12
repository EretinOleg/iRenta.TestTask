using CSharpFunctionalExtensions;
using iRenta.TestTask.Application.Contracts.Messaging;
using iRenta.TestTask.Application.Orders.Dto;
using iRenta.TestTask.Domain.Core.Primitives;

namespace iRenta.TestTask.Application.Orders.Commands;

public record CreateOrderCommand(short Number, string CustomerName, IEnumerable<OrderItemDto> Items) : ICommand<Result<OrderResponse, Error>>;
