using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InvalidQuantityBaseBaseException : WarehouseBaseBaseException
{
    public InvalidQuantityBaseBaseException(string action) 
        : base($"مقدار برای عملیات '{action}' باید عددی مثبت باشد.", "Inventory.InvalidQuantity") { }
}