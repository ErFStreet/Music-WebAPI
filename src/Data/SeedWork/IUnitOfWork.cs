namespace Data.SeedWork;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellation);
}
