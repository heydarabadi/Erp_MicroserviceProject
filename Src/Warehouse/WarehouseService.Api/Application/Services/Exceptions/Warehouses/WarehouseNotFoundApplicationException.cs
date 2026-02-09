using WarehouseService.Api.Application.Services.Exceptions.Shared;

namespace WarehouseService.Api.Application.Services.Exceptions.Warehouses;

public class WarehouseNotFoundApplicationException:WarehouseBaseApplicationException
{
    private const string message = "Warehouse Not Found";
    public WarehouseNotFoundApplicationException() : base(message) { }
}