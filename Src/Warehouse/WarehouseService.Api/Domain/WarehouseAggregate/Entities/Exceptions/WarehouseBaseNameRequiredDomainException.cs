using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseBaseNameRequiredDomainException : WarehouseBaseDomainException
{
    public WarehouseBaseNameRequiredDomainException() : base("نام انبار نمی‌تواند خالی باشد.", "Warehouse.NameRequired")
    {
    }
}