using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InvalidWarehouseBaseNameBaseException : WarehouseBaseBaseException
{
    public InvalidWarehouseBaseNameBaseException() 
        : base("نام انبار نامعتبر است یا نمی‌تواند خالی باشد.", "Warehouse.InvalidName") { }
}