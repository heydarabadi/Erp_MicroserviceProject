using Shared.Application.CqrsConfig.Contracts;
using WarehouseService.Api.Shared.Dtos;

namespace WarehouseService.Api.Application.Services.Warehouses.Commands.Create;

public sealed record CreateWarehouseCommand(string name, int capacity, bool isActive, LocationDto location) 
    : ICommand<CreateWarehouseCommand, ValueTask<bool>>;