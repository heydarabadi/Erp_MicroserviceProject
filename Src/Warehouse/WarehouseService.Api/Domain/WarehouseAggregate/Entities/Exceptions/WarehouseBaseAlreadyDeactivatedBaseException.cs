using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseBaseAlreadyDeactivatedBaseException : WarehouseBaseBaseException
{
    public WarehouseBaseAlreadyDeactivatedBaseException() : base("این انبار در حال حاضر غیرفعال است.",
        "Warehouse.AlreadyDeactivated")
    {
    }
}