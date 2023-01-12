using iRenta.TestTask.Application.Orders.Dto;

namespace iRenta.TestTask.Api.Contracts.Requests.Orders;

public record OrderRequest(short Number, string CustomerName, IEnumerable<OrderItemDto> Items);
