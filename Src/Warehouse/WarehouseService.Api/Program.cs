using System.Reflection;
using Microsoft.Extensions.Options;
using Shared.Application.DependencyInjections;
using Shared.Infrastructure.OptionPatternConfiguration;
using Shared.Ui;
using WarehouseService.Api.Infrastructure;
using WarehouseService.Api.Infrastructure.ApplicationOptions;
using WarehouseService.Api.Ui.Warehouses;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddUiSharedBuildServices(Assembly.GetExecutingAssembly());

#region Option Pattern
builder.Services.AddOptionsFromConfig<WarehouseOption>(builder.Configuration);
var serviceProvider = builder.Services.BuildServiceProvider();
var warehouseOption = serviceProvider.GetRequiredService<IOptions<WarehouseOption>>().Value;
#endregion

#region DatabaseConfig
builder.Services.AddInfrastructureDependencies(builder, warehouseOption);
#endregion

var app = builder.Build();

app.UseUiSharedBuildServices(builder.Configuration);


#region Register Endpoints
app.MapWarehosueEndpoints();
#endregion


await app.RunAsync();