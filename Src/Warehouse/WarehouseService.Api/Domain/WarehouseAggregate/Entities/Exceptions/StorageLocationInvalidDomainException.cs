using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class StorageLocationInvalidDomainException : WarehouseDomainException
{
    public StorageLocationInvalidDomainException(string message) 
        : base(message, "Warehouse.InvalidStorageLocation") { }
}