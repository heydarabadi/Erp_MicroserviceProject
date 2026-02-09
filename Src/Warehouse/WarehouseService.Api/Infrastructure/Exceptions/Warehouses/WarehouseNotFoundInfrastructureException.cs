using WarehouseService.Api.Infrastructure.Shared.Exceptions;

namespace WarehouseService.Api.Infrastructure.Exceptions.Warehouses;

public class WarehouseNotFoundInfrastructureException:WarehouseInfrastructureException
{
    private const string message = "Warehouse Not Found";
    public WarehouseNotFoundInfrastructureException() : base(message)
    {
    }
}