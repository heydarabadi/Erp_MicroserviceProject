using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class InventoryNotBelongToWarehouseBaseBaseException : WarehouseBaseBaseException
{
    public InventoryNotBelongToWarehouseBaseBaseException() 
        : base("این کالا متعلق به این انبار نیست.", "Warehouse.InventoryMismatch") { }
}