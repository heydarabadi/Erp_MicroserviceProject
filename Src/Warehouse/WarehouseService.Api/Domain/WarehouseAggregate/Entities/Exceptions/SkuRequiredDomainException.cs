using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class SkuRequiredDomainException : WarehouseDomainException
{
    public SkuRequiredDomainException() : base("کد کالا (SKU) الزامی است.", "Inventory.SkuRequired") { }
}