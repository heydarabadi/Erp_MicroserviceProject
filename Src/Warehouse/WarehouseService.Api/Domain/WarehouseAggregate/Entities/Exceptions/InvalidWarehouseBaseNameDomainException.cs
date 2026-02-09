using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InvalidWarehouseBaseNameDomainException : WarehouseBaseDomainException
{
    public InvalidWarehouseBaseNameDomainException() 
        : base("نام انبار نامعتبر است یا نمی‌تواند خالی باشد.", "Warehouse.InvalidName") { }
}