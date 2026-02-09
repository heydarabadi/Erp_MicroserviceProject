using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Infrastructure.Exceptions.Warehouses;

public class WarehouseBaseAlreadyExistInfrastructureException:WarehouseBaseDomainException
{
    private const string message = "Warehouse Already Exist";
    public WarehouseBaseAlreadyExistInfrastructureException() : base(message)
    {
    }
}