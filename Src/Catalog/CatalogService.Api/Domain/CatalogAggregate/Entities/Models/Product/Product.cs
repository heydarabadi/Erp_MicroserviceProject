using CatalogService.Api.Domain.CatalogAggregate.Entities.Models.ProductToCategory;
using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Product;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.Entities.Models.Product;

public class Product:AuditableAggregateRoot<Guid>
{
    public ProductName Name { get; private set; }
    public List<ProductToCategories> Categories { get; set; }
}