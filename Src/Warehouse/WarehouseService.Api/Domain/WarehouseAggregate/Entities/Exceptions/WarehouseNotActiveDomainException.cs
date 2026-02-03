using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseNotActiveDomainException : WarehouseDomainException
{
    public WarehouseNotActiveDomainException() 
        : base("انبار غیرفعال است و امکان ثبت موجودی جدید در آن وجود ندارد.", "Warehouse.NotActive") { }
}