using Shared.Application.Repositories;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

namespace WarehouseService.Api.Application.Repositories.Warehouses;

public interface IWarehouseRepository:IRepository<Guid,Warehouse>
{
    Task<Warehouse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task AddAsync(Warehouse entity, CancellationToken cancellationToken = default);

    void Add(Warehouse entity);

    void Update(Warehouse entity);

    void Delete(Warehouse entity);

    Task<List<Warehouse>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Warehouse> GetAsync(string name, CancellationToken cancellationToken);
}