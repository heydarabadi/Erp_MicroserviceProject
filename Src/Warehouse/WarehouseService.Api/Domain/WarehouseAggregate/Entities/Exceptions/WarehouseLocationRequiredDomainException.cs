using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseLocationRequiredDomainException : WarehouseDomainException
{
    public WarehouseLocationRequiredDomainException() 
        : base("ثبت موقعیت مکانی (Location) برای انبار الزامی است.", "Warehouse.LocationRequired") { }
}