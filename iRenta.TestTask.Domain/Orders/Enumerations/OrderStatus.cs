using CSharpFunctionalExtensions;

namespace iRenta.TestTask.Domain.Orders.Enumerations;

public class OrderStatus : EnumValueObject<OrderStatus, int>
{
    public static OrderStatus Registered = new OrderStatus(1, "Registered");

    public static OrderStatus Formed = new OrderStatus(2, "Formed");

    public static OrderStatus Executed = new OrderStatus(3, "Executed");

    public static OrderStatus Canceled = new OrderStatus(4, "Canceled");

    public OrderStatus(int id, string name) : base(id, name)
    {
    }
}
