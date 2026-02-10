using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseBaseCapacityInsufficientForLocationsBaseException : WarehouseBaseBaseException
{
    public WarehouseBaseCapacityInsufficientForLocationsBaseException() : base(
        "ظرفیت جدید نمی‌تواند کمتر از تعداد جایگاه‌های فعلی باشد.", "Warehouse.CapacityInsufficient")
    {
    }
}