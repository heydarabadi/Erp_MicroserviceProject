using Shared.Domain;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

public class WarehouseBaseBaseException : BaseException
{
    public WarehouseBaseBaseException(string message) 
        : base(message, "Warehouse Domain Exception") // کد پایه برای تمام خطاهای انبار
    {
    }

    protected WarehouseBaseBaseException(string message, string code) 
        : base(message, code)
    {
    }
}