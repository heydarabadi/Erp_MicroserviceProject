using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Exceptions;

// خطای خالی بودن آدرس
public class AddressRequiredException : WarehouseBaseDomainException
{
    public AddressRequiredException() 
        : base("آدرس پستی انبار نمی‌تواند خالی باشد.", "Warehouse.AddressRequired") { }
}