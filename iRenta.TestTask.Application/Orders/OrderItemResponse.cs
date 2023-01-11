using iRenta.TestTask.Application.Products;

namespace iRenta.TestTask.Application.Orders;

public record OrderItemResponse(ProductResponse Product, byte Count);
