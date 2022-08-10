namespace Roosevelt.Common.Persistence;

public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
    where TEntity : class, IEntity
{
    TEntity Create(TEntity entity);
    Task<TEntity> CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(object id);
    void Delete(TEntity entity);
    Task DeleteAsync(object id);
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}