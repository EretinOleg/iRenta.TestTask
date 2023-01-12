using CSharpFunctionalExtensions;

namespace iRenta.TestTask.Domain.Core.Extensions;

public static class ResultExtensions
{
    /// <summary>
    /// Returns the result of success or failure functions
    /// </summary>
    public static T Match<T, E>(this UnitResult<E> result, Func<T> onSuccess, Func<E, T> onFailure) =>
        result.IsSuccess
            ? onSuccess()
            : onFailure(result.Error);
}
