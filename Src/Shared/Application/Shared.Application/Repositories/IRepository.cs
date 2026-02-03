using Shared.Domain;

namespace Shared.Application.Repositories;

public interface IRepository<TId, TEntity> where TEntity : Entity<TId>
{
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    IEnumerable<Entity> GetAllAsync(CancellationToken cancellationToken = default);
}