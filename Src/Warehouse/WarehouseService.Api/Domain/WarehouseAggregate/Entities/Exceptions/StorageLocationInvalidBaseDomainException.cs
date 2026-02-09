using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class StorageLocationInvalidBaseDomainException : WarehouseBaseDomainException
{
    public StorageLocationInvalidBaseDomainException(string message) 
        : base(message, "Warehouse.InvalidStorageLocation") { }
}