using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class ShippingExceedsReservedQuantityBaseDomainException : WarehouseBaseDomainException
{
    public ShippingExceedsReservedQuantityBaseDomainException(int shipQty, int reservedQty) 
        : base($"مقدار خروجی ({shipQty}) نمی‌تواند از مقدار رزرو شده ({reservedQty}) بیشتر باشد.", "Inventory.ShippingError") { }
}