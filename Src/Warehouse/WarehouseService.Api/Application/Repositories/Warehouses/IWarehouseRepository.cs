using Shared.Application.Repositories;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

namespace WarehouseService.Api.Application.Repositories.Warehouses;

public interface IWarehouseRepository:IRepository<Guid,Warehouse>
{
    
}