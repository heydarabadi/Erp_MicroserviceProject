namespace CatalogService.Api.ApplicationOptions;

public sealed class CatalogOptions
{
    public MongoDbOptions MongoDbOptions { get; set; }
}

public sealed class MongoDbOptions
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}