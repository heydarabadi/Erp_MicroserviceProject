using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseBaseAtCapacityDomainException : WarehouseBaseDomainException
{
    public WarehouseBaseAtCapacityDomainException() 
        : base("ظرفیت کل انبار تکمیل شده است و امکان پذیرش کالای جدید نیست.", "Warehouse.AtCapacity") { }
}