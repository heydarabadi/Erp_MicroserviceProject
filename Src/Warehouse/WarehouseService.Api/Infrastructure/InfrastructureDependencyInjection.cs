using Microsoft.EntityFrameworkCore;
using Shared.Application.Repositories;
using WarehouseService.Api.Application.Repositories.Warehouses;
using WarehouseService.Api.Infrastructure.ApplicationOptions;
using WarehouseService.Api.Infrastructure.Db.PostgresSql.DatabaseContexts;
using WarehouseService.Api.Infrastructure.Persistance.Repositories.Warehouses;
using WarehouseService.Api.Infrastructure.Persistance.UnitOfWorkConfiguration;

namespace WarehouseService.Api.Infrastructure;



public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service, WebApplicationBuilder builder,
        WarehouseOption warehouseOption)
    {
        var databaseConfiguration = warehouseOption.Database;
        
        service
            .AddDbContextPool<WarehouseDbContext>(options =>
        {
            options
                .UseNpgsql(databaseConfiguration.ConnectionStrings, 
                    npgsql =>
            {
                npgsql
                    .CommandTimeout(databaseConfiguration.TimeOut);

                npgsql.
                    EnableRetryOnFailure(maxRetryCount: databaseConfiguration.MaxRetryCount,
                        maxRetryDelay: TimeSpan.FromSeconds(databaseConfiguration.MaxRetryDelay),
                        null);

            });

            if (builder.Environment.IsDevelopment())
            {
                options
                    .EnableSensitiveDataLogging();
                
                options
                    .EnableDetailedErrors();
            }
        });
        
        builder.Services
            .AddScoped<IUnitOfWork, UnitOfWork>();
        
        
        builder.Services
            .AddScoped(typeof(IWarehouseRepository),
            typeof(WarehouseRepository));

        return service;
    }
}