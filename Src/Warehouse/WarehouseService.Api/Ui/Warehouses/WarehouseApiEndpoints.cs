using Shared.Application.CqrsConfig.Contracts;
using WarehouseService.Api.Application.Services.Warehouses.Commands.AddStorageLocationToWarehouse.Command;
using WarehouseService.Api.Application.Services.Warehouses.Commands.Create;
using WarehouseService.Api.Application.Services.Warehouses.Queries.GetByName.Queries;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

namespace WarehouseService.Api.Ui.Warehouses;

public static class WarehouseApiEndpoints
{
    public static IEndpointRouteBuilder MapWarehosueEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        var group = routeBuilder
            .MapGroup("/api/warehouses/")
            .WithTags("warehouses");

        #region Commands
        
        group.MapPost("/", async (IMediator mediator, CreateWarehouseCommand request) =>
        {
            var result = await mediator.Send<CreateWarehouseCommand, ValueTask<bool>>(request);

            return Results.Created();
        });
        
        
        group.MapPut("/AddStorageLocation", async (IMediator mediator, AddStorageLocationToWarehouseCommand request) =>
        {
            var result = await mediator.Send<AddStorageLocationToWarehouseCommand, ValueTask<bool>>(request);

            return Results.Created();
        });

        #endregion

        #region Queries

        group.MapGet("/GetByName", async (IMediator mediator, string name) =>
        {
            var findWarehouse = await mediator.Send<GetWarehouseByNameQuery, ValueTask<Warehouse?>>
                (new GetWarehouseByNameQuery(name));
            
            return Results.Ok(findWarehouse);
        });

        #endregion


        return routeBuilder;
    }
}