using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseAtCapacityDomainException : WarehouseDomainException
{
    public WarehouseAtCapacityDomainException() 
        : base("ظرفیت کل انبار تکمیل شده است و امکان پذیرش کالای جدید نیست.", "Warehouse.AtCapacity") { }
}