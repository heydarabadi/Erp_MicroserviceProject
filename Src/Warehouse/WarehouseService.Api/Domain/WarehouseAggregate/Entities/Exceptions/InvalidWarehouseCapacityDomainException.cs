using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InvalidWarehouseCapacityDomainException : WarehouseDomainException
{
    public InvalidWarehouseCapacityDomainException() : base("ظرفیت انبار باید عددی مثبت باشد.", "Warehouse.InvalidCapacity")
    {
    }
}