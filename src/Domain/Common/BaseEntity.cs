namespace Domain.Common;

public abstract class BaseEntity<TKey> : IEntity<TKey> where TKey : notnull
{
    public TKey Id { get; set; } = default!;
}

