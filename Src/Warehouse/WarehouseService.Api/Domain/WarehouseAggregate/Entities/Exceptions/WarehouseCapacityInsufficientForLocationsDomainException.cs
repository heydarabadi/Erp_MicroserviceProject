using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseCapacityInsufficientForLocationsDomainException : WarehouseDomainException
{
    public WarehouseCapacityInsufficientForLocationsDomainException() : base(
        "ظرفیت جدید نمی‌تواند کمتر از تعداد جایگاه‌های فعلی باشد.", "Warehouse.CapacityInsufficient")
    {
    }
}