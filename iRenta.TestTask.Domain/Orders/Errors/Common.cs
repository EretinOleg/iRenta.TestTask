using iRenta.TestTask.Domain.Core.Primitives;

namespace iRenta.TestTask.Domain.Orders.Errors;

/// <summary>
/// Common domain errors
/// </summary>
public static class Common
{
    /// <summary>
    /// Contains general errors
    /// </summary>
    public static class General
    {
        public static Error ServerError => new Error("Common.General.ServerError", "The server encountered an unrecoverable error.");
    }
}
