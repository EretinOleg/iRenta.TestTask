namespace iRenta.TestTask.Application.Products;

public record ProductResponse(Guid Id, sbyte VendorCode, string Name, decimal Price);
