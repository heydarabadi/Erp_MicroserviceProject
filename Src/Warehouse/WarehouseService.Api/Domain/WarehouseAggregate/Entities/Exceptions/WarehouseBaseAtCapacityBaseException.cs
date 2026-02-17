using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseBaseAtCapacityBaseException : WarehouseBaseBaseException
{
    public WarehouseBaseAtCapacityBaseException() 
        : base("ظرفیت کل انبار تکمیل شده است و امکان پذیرش کالای جدید نیست.", "Warehouse.AtCapacity") { }
}