using iRenta.TestTask.Domain.Core.Primitives;

namespace iRenta.TestTask.Persistence.Repositories;

/// <summary>
/// Base class for all repositories
/// </summary>
public abstract class Repository<T> where T : Entity
{
    /// <summary>
    /// Data source
    /// </summary>
    protected abstract IEnumerable<T> DataSource { get; }
}
