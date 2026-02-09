using Shared.Application.CqrsConfig.Contracts;
using Shared.Application.Repositories;
using WarehouseService.Api.Application.Repositories.Warehouses;
using WarehouseService.Api.Application.Services.Exceptions.Warehouses;
using WarehouseService.Api.Application.Services.Warehouses.Commands.AddStorageLocationToWarehouse.Command;

namespace WarehouseService.Api.Application.Services.Warehouses.Commands.AddStorageLocationToWarehouse.Handlers;

public sealed class AddStorageLocationToWarehouseCommandHandler(
    IWarehouseRepository _warehouseRepository,
    IUnitOfWork _unitOfWork) :
    ICommandHandler<AddStorageLocationToWarehouseCommand, ValueTask<bool>>
{
    public async ValueTask<bool> Handle(AddStorageLocationToWarehouseCommand request,
        CancellationToken cancellationToken)
    {
        var findWarehouseWithId = await _warehouseRepository.GetByIdAsync(request.warehouseId,
            cancellationToken);

        if (findWarehouseWithId is null)
            throw new WarehouseNotFoundApplicationException();

        findWarehouseWithId.AddStorageLocation(request.StorageAddressDto.Zone,
            request.StorageAddressDto.Shelf, request.StorageAddressDto.Bin);

        _warehouseRepository.Update(findWarehouseWithId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}