using Shared.Application.CqrsConfig.Contracts;
using WarehouseService.Api.Application.Repositories.Warehouses;
using WarehouseService.Api.Application.Services.Exceptions.Warehouses;
using WarehouseService.Api.Application.Services.Warehouses.Queries.GetByName.Queries;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

namespace WarehouseService.Api.Application.Services.Warehouses.Queries.GetByName.Handlers;

public sealed class GetWarehouseByNameQueryHandler(IWarehouseRepository _warehouseRepository)
    :IQueryHandler<GetWarehouseByNameQuery, ValueTask<Warehouse?>>
{
    public async ValueTask<Warehouse?> Handle(GetWarehouseByNameQuery request, CancellationToken cancellationToken)
    {
        var findWarehouse = await _warehouseRepository
            .GetAsync(request.name, cancellationToken);

        if (findWarehouse is null)
            throw new WarehouseNotFoundApplicationException();
        
        return findWarehouse;
    }
}