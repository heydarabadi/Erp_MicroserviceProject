using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InventoryItemNotFoundBaseDomainException : WarehouseBaseDomainException
{
    public InventoryItemNotFoundBaseDomainException(string sku) 
        : base($"کالایی با کد {sku} یافت نشد.", "Inventory.NotFound") { }
}