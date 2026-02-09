using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class NegativeQuantityBaseDomainException : WarehouseBaseDomainException
{
    public NegativeQuantityBaseDomainException() 
        : base("مقدار عملیات موجودی باید عددی مثبت باشد.", "Inventory.NegativeQuantity") { }
}