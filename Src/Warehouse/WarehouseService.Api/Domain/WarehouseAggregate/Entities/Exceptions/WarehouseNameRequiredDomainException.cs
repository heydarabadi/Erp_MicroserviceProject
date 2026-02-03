using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseNameRequiredDomainException : WarehouseDomainException
{
    public WarehouseNameRequiredDomainException() : base("نام انبار نمی‌تواند خالی باشد.", "Warehouse.NameRequired")
    {
    }
}