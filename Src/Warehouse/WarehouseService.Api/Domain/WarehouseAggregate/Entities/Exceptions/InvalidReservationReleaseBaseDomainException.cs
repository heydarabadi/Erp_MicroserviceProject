using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InvalidReservationReleaseBaseDomainException : WarehouseBaseDomainException
{
    public InvalidReservationReleaseBaseDomainException() 
        : base("مقدار آزادسازی نمی‌تواند بیشتر از مقدار رزرو شده فعلی باشد.", "Inventory.InvalidRelease") { }
}