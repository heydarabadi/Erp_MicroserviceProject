using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class StorageLocationAddressRequiredBaseDomainException : WarehouseBaseDomainException
{
    public StorageLocationAddressRequiredBaseDomainException() 
        : base("آدرس جایگاه (Address) نمی‌تواند خالی باشد.", "Warehouse.AddressRequired") { }
}