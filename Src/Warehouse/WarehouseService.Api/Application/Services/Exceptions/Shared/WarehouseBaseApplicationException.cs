using Shared.Domain;

namespace WarehouseService.Api.Application.Services.Exceptions.Shared;

public class WarehouseBaseApplicationException: DomainException
{
    public WarehouseBaseApplicationException(string message, string? details = null) : base(message, "Warehouse Application Exception", details)
    {
    }

    public WarehouseBaseApplicationException(string message) : base(message, "Warehouse Application Exception")
    {
    }
}