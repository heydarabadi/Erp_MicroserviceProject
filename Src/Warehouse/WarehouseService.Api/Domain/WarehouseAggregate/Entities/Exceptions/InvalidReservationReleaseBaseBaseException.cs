using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InvalidReservationReleaseBaseBaseException : WarehouseBaseBaseException
{
    public InvalidReservationReleaseBaseBaseException() 
        : base("مقدار آزادسازی نمی‌تواند بیشتر از مقدار رزرو شده فعلی باشد.", "Inventory.InvalidRelease") { }
}