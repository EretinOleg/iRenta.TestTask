using CSharpFunctionalExtensions;

namespace iRenta.TestTask.Domain.Core.Primitives;

/// <summary>
/// Base class for all entities
/// </summary>
public abstract class Entity : Entity<Guid>
{
    protected Entity()
    {
    }

    protected Entity(Guid id) : base(id)
    {
    }
}