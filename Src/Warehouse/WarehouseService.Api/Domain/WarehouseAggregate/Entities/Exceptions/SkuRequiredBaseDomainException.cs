using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class SkuRequiredBaseDomainException : WarehouseBaseDomainException
{
    public SkuRequiredBaseDomainException() : base("کد کالا (SKU) الزامی است.", "Inventory.SkuRequired") { }
}