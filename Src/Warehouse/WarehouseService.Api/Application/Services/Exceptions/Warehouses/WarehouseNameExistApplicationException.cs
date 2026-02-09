using WarehouseService.Api.Application.Services.Exceptions.Shared;

namespace WarehouseService.Api.Application.Services.Exceptions.Warehouses;

public class WarehouseNameExistApplicationException : WarehouseBaseApplicationException
{
    public WarehouseNameExistApplicationException() : base("Warehouse With Name Key Is Exist In Database")
    {
    }
}