using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class NegativeTotalStockDomainException : WarehouseDomainException
{
    public NegativeTotalStockDomainException() 
        : base("موجودی کل (OnHand) نمی‌تواند منفی شود.", "Inventory.NegativeTotalStock") { }
}