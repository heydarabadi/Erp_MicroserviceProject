using Shared.Application.CqrsConfig.Contracts;
using WarehouseService.Api.Shared.Dtos;

namespace WarehouseService.Api.Application.Services.Warehouses.Commands.AddStorageLocationToWarehouse.Command;

public sealed record AddStorageLocationToWarehouseCommand(Guid warehouseId, 
    StorageAddressDto StorageAddressDto):ICommand<AddStorageLocationToWarehouseCommand,
    ValueTask<bool>>;