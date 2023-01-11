namespace iRenta.TestTask.Api.Contracts;

public static class ApiRoutes
{
    public static class Product
    {
        public const string Get = "goods";

        public const string GetByCode = "goods/{code:range(1,127)}";
    }

    public static class Order
    {
        public const string Get = "orders";

        public const string GetByNumber = "orders/{number:range(1,32767)}";
    }
}
