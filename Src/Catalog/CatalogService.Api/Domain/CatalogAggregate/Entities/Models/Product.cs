using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Category;
using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Product;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.Entities.Models;

public class Product:AuditableAggregateRoot<Guid>
{
    public CategoryName Name { get; private set; }
}