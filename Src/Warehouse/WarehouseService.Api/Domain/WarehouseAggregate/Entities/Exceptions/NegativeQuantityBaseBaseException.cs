using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class NegativeQuantityBaseBaseException : WarehouseBaseBaseException
{
    public NegativeQuantityBaseBaseException() 
        : base("مقدار عملیات موجودی باید عددی مثبت باشد.", "Inventory.NegativeQuantity") { }
}