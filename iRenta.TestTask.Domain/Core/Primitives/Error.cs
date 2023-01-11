using CSharpFunctionalExtensions;

namespace iRenta.TestTask.Domain.Core.Primitives;

/// <summary>
/// Represents a concrete domain error
/// </summary>
public class Error : ValueObject
{
    /// <summary>
    /// Gets the error code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Message { get; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}

