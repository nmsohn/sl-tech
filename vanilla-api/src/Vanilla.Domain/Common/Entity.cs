namespace Vanilla.Domain.Common;

public abstract class Entity<T>
{
    public virtual T Id { get; set; } = default!;
}