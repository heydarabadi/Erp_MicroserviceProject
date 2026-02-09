using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class StorageLocationInvalidWarehouseBaseDomainException : WarehouseBaseDomainException
{
    public StorageLocationInvalidWarehouseBaseDomainException() 
        : base("شناسه انبار برای ایجاد جایگاه نامعتبر است.", "Warehouse.InvalidId") { }
}