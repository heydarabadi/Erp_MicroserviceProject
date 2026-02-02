using Shared.Domain;

namespace Shared.Application.Repositories;

public interface IRepository<TId, TEntity> where TEntity : Entity<TId>
{
    IUnitOfWork UnitOfWork { get; }
    
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}