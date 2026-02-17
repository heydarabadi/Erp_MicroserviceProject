using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InventoryItemNotFoundBaseBaseException : WarehouseBaseBaseException
{
    public InventoryItemNotFoundBaseBaseException(string sku) 
        : base($"کالایی با کد {sku} یافت نشد.", "Inventory.NotFound") { }
}