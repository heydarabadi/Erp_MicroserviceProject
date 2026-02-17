using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseBaseCapacityReductionBaseException : WarehouseBaseBaseException
{
    public WarehouseBaseCapacityReductionBaseException() 
        : base("کاهش ناگهانی ظرفیت به بیش از ۵۰ درصد مجاز نیست.", "Warehouse.CapacityReductionLimit") { }
}