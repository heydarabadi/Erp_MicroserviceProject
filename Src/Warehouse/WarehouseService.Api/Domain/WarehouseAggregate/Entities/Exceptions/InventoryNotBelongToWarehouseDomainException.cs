using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InventoryNotBelongToWarehouseDomainException : WarehouseDomainException
{
    public InventoryNotBelongToWarehouseDomainException() 
        : base("این کالا متعلق به این انبار نیست.", "Warehouse.InventoryMismatch") { }
}