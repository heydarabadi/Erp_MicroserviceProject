using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InsufficientAvailableStockBaseDomainException : WarehouseBaseDomainException
{
    public InsufficientAvailableStockBaseDomainException(string sku, int requested, int available) 
        : base($"موجودی قابل تخصیص برای کالا '{sku}' کافی نیست. (درخواست: {requested}، موجود: {available})", "Inventory.InsufficientStock") { }
}