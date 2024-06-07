namespace Data.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    public IQueryable<TEntity> Queryable { get; }

    Task AddAsync(TEntity entity, CancellationToken cancellation);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}
