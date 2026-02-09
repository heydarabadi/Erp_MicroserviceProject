using Shared.Application.CqrsConfig.Contracts;
using Shared.Application.Repositories;
using WarehouseService.Api.Application.Repositories.Warehouses;
using WarehouseService.Api.Application.Services.Exceptions.Warehouses;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

namespace WarehouseService.Api.Application.Services.Warehouses.Commands.Create;

public sealed class CreateWarehouseHandler(IWarehouseRepository _warehouseRepository,
    IUnitOfWork _unitOfWork)
    : ICommandHandler<CreateWarehouseCommand, ValueTask<bool>>
{
    public async ValueTask<bool> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var findWarehouse = await _warehouseRepository.GetAsync(request.name,
            cancellationToken);

        if (findWarehouse is not null)
            throw new WarehouseNameExistApplicationException();


        Warehouse warehouse = Warehouse.Create(name: request.name,
            location: request.location,
            capacity: request.capacity
        );

        await _warehouseRepository.AddAsync(warehouse);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
        
        


    }
}