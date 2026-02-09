using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InvalidWarehouseBaseCapacityDomainException : WarehouseBaseDomainException
{
    public InvalidWarehouseBaseCapacityDomainException() : base("ظرفیت انبار باید عددی مثبت باشد.", "Warehouse.InvalidCapacity")
    {
    }
}