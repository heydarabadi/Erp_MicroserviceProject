using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class StorageLocationAddressRequiredDomainException : WarehouseDomainException
{
    public StorageLocationAddressRequiredDomainException() 
        : base("آدرس جایگاه (Address) نمی‌تواند خالی باشد.", "Warehouse.AddressRequired") { }
}