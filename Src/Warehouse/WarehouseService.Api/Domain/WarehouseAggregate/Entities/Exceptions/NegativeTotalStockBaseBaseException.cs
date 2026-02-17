using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class NegativeTotalStockBaseBaseException : WarehouseBaseBaseException
{
    public NegativeTotalStockBaseBaseException() 
        : base("موجودی کل (OnHand) نمی‌تواند منفی شود.", "Inventory.NegativeTotalStock") { }
}