namespace Domain.Common.Contract;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}
