using System.Windows.Input;
using Shared.Application.CqrsConfig;
using Warehouse.Api.Application.WarehouseAggregate.Commands.Dto;

namespace Warehouse.Api.Application.WarehouseAggregate.Commands.Create;

public sealed class CreateWarehouseCommand(string Name, int Capacity, bool IsActive, LocationDto Location) : ICommand<CreateWarehouseCommand, bool>;