using Shared.Domain;

namespace Shared.Application.Repositories;

public interface IRepository<TId, TEntity> where TEntity : Entity<TId>
{
    IUnitOfWork UnitOfWork { get; }
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    void AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    IEnumerable<Entity> GetAllAsync(CancellationToken cancellationToken = default);
}