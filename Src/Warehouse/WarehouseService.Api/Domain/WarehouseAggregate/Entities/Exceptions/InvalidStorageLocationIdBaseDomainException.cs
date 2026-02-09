using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InvalidStorageLocationIdBaseDomainException : WarehouseBaseDomainException
{
    public InvalidStorageLocationIdBaseDomainException() 
        : base("شناسه جایگاه فیزیکی (Storage Location) نامعتبر است.", "Inventory.InvalidLocation") { }
}