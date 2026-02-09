using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class StorageLocationMismatchBaseDomainException : WarehouseBaseDomainException
{
    public StorageLocationMismatchBaseDomainException() 
        : base("جایگاه فیزیکی انتخاب شده متعلق به این انبار نیست.", "Inventory.LocationMismatch") { }
}