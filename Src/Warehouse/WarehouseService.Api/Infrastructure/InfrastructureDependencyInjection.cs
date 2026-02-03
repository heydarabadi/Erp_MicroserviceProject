using Microsoft.EntityFrameworkCore;
using WarehouseService.Api.Infrastructure.ApplicationOptions;
using WarehouseService.Api.Infrastructure.Db.PostgresSql.DatabaseContexts;

namespace WarehouseService.Api.Infrastructure;



public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection service, WebApplicationBuilder builder,
        WarehouseOption warehouseOption)
    {
        var databaseConfiguration = warehouseOption.Database;
        
        service.AddDbContextPool<WarehouseDbContext>(options =>
        {
            options.UseNpgsql(databaseConfiguration.ConnectionStrings, npgsql =>
            {
                npgsql.CommandTimeout(databaseConfiguration.TimeOut);

                npgsql.
                    EnableRetryOnFailure(maxRetryCount: databaseConfiguration.MaxRetryCount,
                        maxRetryDelay: TimeSpan.FromSeconds(databaseConfiguration.MaxRetryDelay),
                        null);

            });

            if (builder.Environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            }
        });

        return service;
    }
}