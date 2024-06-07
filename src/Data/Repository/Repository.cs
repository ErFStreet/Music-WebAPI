namespace Data.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _entity;

    public IQueryable<TEntity> Queryable => _entity.AsQueryable();

    public Repository(ApplicationDbContext dbContext)
    {
        _entity = dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellation)
    {
        await _entity.AddAsync(entity, cancellation);
    }

    public void Update(TEntity entity)
    {
        _entity.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _entity.Remove(entity);
    }
}
