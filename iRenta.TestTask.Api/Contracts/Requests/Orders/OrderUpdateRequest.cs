using iRenta.TestTask.Application.Orders.Dto;

namespace iRenta.TestTask.Api.Contracts.Requests.Orders;

public record OrderUpdateRequest(string CustomerName, IEnumerable<OrderItemDto> Items);