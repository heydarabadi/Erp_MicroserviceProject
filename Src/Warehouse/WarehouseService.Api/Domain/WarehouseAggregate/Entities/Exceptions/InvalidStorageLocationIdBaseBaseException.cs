using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InvalidStorageLocationIdBaseBaseException : WarehouseBaseBaseException
{
    public InvalidStorageLocationIdBaseBaseException() 
        : base("شناسه جایگاه فیزیکی (Storage Location) نامعتبر است.", "Inventory.InvalidLocation") { }
}