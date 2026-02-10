using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseBaseNameRequiredBaseException : WarehouseBaseBaseException
{
    public WarehouseBaseNameRequiredBaseException() : base("نام انبار نمی‌تواند خالی باشد.", "Warehouse.NameRequired")
    {
    }
}