using Shared.Domain;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

public class WarehouseBaseDomainException : DomainException
{
    public WarehouseBaseDomainException(string message) 
        : base(message, "Warehouse Domain Exception") // کد پایه برای تمام خطاهای انبار
    {
    }

    protected WarehouseBaseDomainException(string message, string code) 
        : base(message, code)
    {
    }
}