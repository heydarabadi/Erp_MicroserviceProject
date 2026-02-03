using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InvalidQuantityDomainException : WarehouseDomainException
{
    public InvalidQuantityDomainException(string action) 
        : base($"مقدار برای عملیات '{action}' باید عددی مثبت باشد.", "Inventory.InvalidQuantity") { }
}