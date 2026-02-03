using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InventoryItemNotFoundDomainException : WarehouseDomainException
{
    public InventoryItemNotFoundDomainException(string sku) 
        : base($"کالایی با کد {sku} یافت نشد.", "Inventory.NotFound") { }
}