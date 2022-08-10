namespace Roosevelt.Common.Persistence;

public interface IDataContext
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}