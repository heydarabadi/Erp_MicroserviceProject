using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseIsFullDomainException : WarehouseDomainException
{
    public WarehouseIsFullDomainException() : base("ظرفیت انبار برای تعریف جایگاه جدید تکمیل است.", "Warehouse.Full")
    {
    }
}