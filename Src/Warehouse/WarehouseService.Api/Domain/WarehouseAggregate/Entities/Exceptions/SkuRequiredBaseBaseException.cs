using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class SkuRequiredBaseBaseException : WarehouseBaseBaseException
{
    public SkuRequiredBaseBaseException() : base("کد کالا (SKU) الزامی است.", "Inventory.SkuRequired") { }
}