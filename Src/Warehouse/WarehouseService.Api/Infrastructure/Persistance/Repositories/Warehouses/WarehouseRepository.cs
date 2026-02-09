using Microsoft.EntityFrameworkCore;
using WarehouseService.Api.Application.Repositories.Warehouses;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;
using WarehouseService.Api.Infrastructure.Db.PostgresSql.DatabaseContexts;
using WarehouseService.Api.Infrastructure.Exceptions.Warehouses;

namespace WarehouseService.Api.Infrastructure.Persistance.Repositories.Warehouses;

public class WarehouseRepository(WarehouseDbContext _warehouseDbContext)
    :IWarehouseRepository
{
    public async Task<Warehouse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var warehouse = await _warehouseDbContext
            .Warehouses
            .FindAsync(id, cancellationToken);

        if (warehouse is null)
            throw new WarehouseNotFoundInfrastructureException();

        return warehouse;
        
    }

    public async Task AddAsync(Warehouse entity, CancellationToken cancellationToken = default)
    {
        var exist = await _warehouseDbContext
            .Warehouses
            .AnyAsync(x=>x.Id == entity.Id, cancellationToken);

        if (exist)
            throw new WarehouseBaseAlreadyExistInfrastructureException();
        
        await _warehouseDbContext.AddAsync(entity, cancellationToken);
    }

    public void Add(Warehouse entity)
    {
        var exist =  _warehouseDbContext
            .Warehouses
            .Any(x=>x.Id == entity.Id);

        if (exist)
            throw new WarehouseBaseAlreadyExistInfrastructureException();
        
        _warehouseDbContext.Warehouses.Add(entity);    
    }

    public void Update(Warehouse entity)
    {
        var warehouse = _warehouseDbContext
            .Warehouses
            .Find(entity.Id);

        if (warehouse is null)
            throw new WarehouseNotFoundInfrastructureException();
        
        _warehouseDbContext.Warehouses.Update(entity);
    }

    public void Delete(Warehouse entity)
    {
        var warehouse =  _warehouseDbContext
            .Warehouses
            .Find(entity.Id);

        if (warehouse is null)
            throw new WarehouseBaseAlreadyExistInfrastructureException();
        
        _warehouseDbContext.Warehouses.Remove(entity);
        
    }

    public async Task<List<Warehouse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var warehouses = await _warehouseDbContext
            .Warehouses
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return warehouses;
    }

    public async Task<Warehouse> GetAsync(string name, CancellationToken cancellationToken)
    {
        Warehouse? warehouse = await _warehouseDbContext.Warehouses
            .FirstOrDefaultAsync(x => x.Name == name, 
                cancellationToken);

        return warehouse;
    }
}