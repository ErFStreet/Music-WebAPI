namespace Data.SeedWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellation)
    {
        var affectedRows =
               await _applicationDbContext.SaveChangesAsync(cancellation);

        return affectedRows;
    }
}
