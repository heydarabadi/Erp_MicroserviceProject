using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

// اکسپشن برای شناسه‌های خالی یا نامعتبر
public class InvalidWarehouseBaseIdDomainException : WarehouseBaseDomainException
{
    public InvalidWarehouseBaseIdDomainException() 
        : base("شناسه انبار نامعتبر است.", "Inventory.InvalidWarehouse") { }
}