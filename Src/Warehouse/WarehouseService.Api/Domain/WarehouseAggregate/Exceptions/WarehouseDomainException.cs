using Shared.Domain;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

public class WarehouseDomainException : DomainException
{
    public WarehouseDomainException(string message) 
        : base(message, "Warehouse Domain Exception") // کد پایه برای تمام خطاهای انبار
    {
    }

    protected WarehouseDomainException(string message, string code) 
        : base(message, code)
    {
    }
}