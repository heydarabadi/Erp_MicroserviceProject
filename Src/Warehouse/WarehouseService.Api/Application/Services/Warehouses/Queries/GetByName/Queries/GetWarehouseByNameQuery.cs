using Shared.Application.CqrsConfig.Contracts;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

namespace WarehouseService.Api.Application.Services.Warehouses.Queries.GetByName.Queries;

public sealed record GetWarehouseByNameQuery(string name)
    :IQuery<GetWarehouseByNameQuery, ValueTask<Warehouse?>>;