using System.Text.Json.Serialization;
using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.MoneyUnits;
using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Product;
using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.TechnicalNumber;
using MongoDB.Bson;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.Entities.Models.Product;

public class Product:AuditableAggregateRoot<ObjectId>
{
    public Guid DomainId { get; private set; }
    public ProductName Name { get; private set; }
    [JsonIgnore]
    public List<ObjectId> CategoriesIds { get; set; } = new List<ObjectId>();
    [JsonIgnore]
    public List<ObjectId> PropertyIds { get; private set; } = new List<ObjectId>();
    public Price SalePrice { get; set; }
    public Price ConsumerPrice { get; set; }
    public List<string> ImagesUrls { get; set; } = new List<string>();
    public TechnicalNumber TechnicalNumber { get; set; }
    
}