using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class StorageLocationInvalidBaseBaseException : WarehouseBaseBaseException
{
    public StorageLocationInvalidBaseBaseException(string message) 
        : base(message, "Warehouse.InvalidStorageLocation") { }
}