namespace iRenta.TestTask.Api.Contracts;

public static class ApiRoutes
{
    public static class Product
    {
        public const string Get = "goods";

        public const string GetByCode = "goods/{code:int}";
    }
}
