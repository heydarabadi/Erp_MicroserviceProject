using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Infrastructure.Exceptions.Warehouses;

public class WarehouseAlreadyExistInfrastructureException:WarehouseDomainException
{
    private const string message = "Warehouse Already Exist";
    public WarehouseAlreadyExistInfrastructureException() : base(message)
    {
    }
}