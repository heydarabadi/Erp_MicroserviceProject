using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InvalidWarehouseBaseCapacityBaseException : WarehouseBaseBaseException
{
    public InvalidWarehouseBaseCapacityBaseException() : base("ظرفیت انبار باید عددی مثبت باشد.", "Warehouse.InvalidCapacity")
    {
    }
}