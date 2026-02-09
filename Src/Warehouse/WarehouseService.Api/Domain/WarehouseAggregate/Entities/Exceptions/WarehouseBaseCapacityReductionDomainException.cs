using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class WarehouseBaseCapacityReductionDomainException : WarehouseBaseDomainException
{
    public WarehouseBaseCapacityReductionDomainException() 
        : base("کاهش ناگهانی ظرفیت به بیش از ۵۰ درصد مجاز نیست.", "Warehouse.CapacityReductionLimit") { }
}