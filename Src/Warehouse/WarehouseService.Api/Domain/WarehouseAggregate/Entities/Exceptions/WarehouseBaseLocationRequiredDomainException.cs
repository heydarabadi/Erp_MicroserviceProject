using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseBaseLocationRequiredDomainException : WarehouseBaseDomainException
{
    public WarehouseBaseLocationRequiredDomainException() 
        : base("ثبت موقعیت مکانی (Location) برای انبار الزامی است.", "Warehouse.LocationRequired") { }
}