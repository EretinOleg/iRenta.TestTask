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

        public const string GetForDate = "orders/{date:regex(^\\d{{4}}-\\d{{2}}-\\d{{2}}$)}";

        public const string Remove = "orders/{number:range(1,32767)}";

        public const string Create = "orders";

        public const string Update = "orders/{number:range(1,32767)}";

        public const string Patch = "orders/{number:range(1,32767)}";
    }
}
