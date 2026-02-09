using CatalogService.Api.Domain.CatalogAggregate.Entities.Models.ProductToCategory;
using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Product;
using MongoDB.Bson;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.Entities.Models.Product;

public class Product:AuditableAggregateRoot<ObjectId>
{
    public ObjectId Id { get; private set; }
    public Guid DomainId { get; private set; }
    public ProductName Name { get; private set; }
    public List<ProductToCategories> Categories { get; set; }
}