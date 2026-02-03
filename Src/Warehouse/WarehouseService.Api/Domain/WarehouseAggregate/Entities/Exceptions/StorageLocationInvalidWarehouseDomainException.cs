using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class StorageLocationInvalidWarehouseDomainException : WarehouseDomainException
{
    public StorageLocationInvalidWarehouseDomainException() 
        : base("شناسه انبار برای ایجاد جایگاه نامعتبر است.", "Warehouse.InvalidId") { }
}