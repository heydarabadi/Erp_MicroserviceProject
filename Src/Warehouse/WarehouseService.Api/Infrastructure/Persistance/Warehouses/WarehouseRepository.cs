using Shared.Application.Repositories;
using Shared.Domain;
using WarehouseService.Api.Application.Repositories.Warehouses;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;
using WarehouseService.Api.Infrastructure.Db.PostgresSql.DatabaseContexts;
using WarehouseService.Api.Infrastructure.Exceptions.Warehouses;

namespace WarehouseService.Api.Infrastructure.Persistance.Warehouses;

public class WarehouseRepository(WarehouseDbContext _warehouseDbContext)
    :IWarehouseRepository
{
    public IUnitOfWork UnitOfWork { get; }
    public async Task<Warehouse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var warehouse = await _warehouseDbContext
            .Warehouses
            .FindAsync(id,cancellationToken);

        if (warehouse is null)
            throw new WarehouseNotFoundInfrastructureException();
        
        

    }

    public void AddAsync(Warehouse entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Update(Warehouse entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Warehouse entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Entity> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}