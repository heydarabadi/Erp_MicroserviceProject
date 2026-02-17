using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseBaseIsFullBaseException : WarehouseBaseBaseException
{
    public WarehouseBaseIsFullBaseException() : base("ظرفیت انبار برای تعریف جایگاه جدید تکمیل است.", "Warehouse.Full")
    {
    }
}