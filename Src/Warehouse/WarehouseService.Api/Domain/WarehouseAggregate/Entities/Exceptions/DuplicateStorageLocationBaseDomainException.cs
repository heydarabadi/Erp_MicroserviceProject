using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

public class DuplicateStorageLocationBaseDomainException : WarehouseBaseDomainException
{
    // تغییر سازنده برای پذیرش ۳ پارامتر
    public DuplicateStorageLocationBaseDomainException(string zone, string shelf, string bin) 
        : base($"جایگاه '{zone}-{shelf}-{bin}' قبلاً در این انبار تعریف شده است.", "Warehouse.DuplicateLocation") { }
}