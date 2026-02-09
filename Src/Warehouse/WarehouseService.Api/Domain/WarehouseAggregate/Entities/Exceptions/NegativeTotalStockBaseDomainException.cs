using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class NegativeTotalStockBaseDomainException : WarehouseBaseDomainException
{
    public NegativeTotalStockBaseDomainException() 
        : base("موجودی کل (OnHand) نمی‌تواند منفی شود.", "Inventory.NegativeTotalStock") { }
}