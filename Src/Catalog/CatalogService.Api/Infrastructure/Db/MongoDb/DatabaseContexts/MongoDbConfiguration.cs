using CatalogService.Api.ApplicationOptions;
using CatalogService.Api.Domain.CatalogAggregate.Entities.Models.Product;
using MongoDB.Driver;

namespace CatalogService.Api.Infrastructure.Db.MongoDb.DatabaseContexts;

public static class MongoDbConfiguration
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration,
        CatalogOptions options)
    {
        
        services.AddSingleton<IMongoClient>(sp => 
            new MongoClient(options.MongoDbOptions.ConnectionString));
    
        
        services.AddScoped(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(options.MongoDbOptions.DatabaseName);
        });
    
        
        services.AddScoped<IMongoCollection<Product>>(sp =>
        {
            var database = sp.GetRequiredService<IMongoDatabase>();
            return database.GetCollection<Product>(nameof(Product) + "s");
        });
    
        //services.AddScoped<IProductRepository, ProductRepository>();
    
        return services;
    }
}