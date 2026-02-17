using Shared.Domain;

namespace WarehouseService.Api.Infrastructure.Shared.Exceptions;

public class WarehouseInfrastructureException:BaseException
{
    public WarehouseInfrastructureException(string message, string code, string? details = null)
        : base(message, code, details)
    {
    }

    public WarehouseInfrastructureException(string message) :
        base(message, "Warehouse Infrastructure Exception")
    {
    }
}