using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Product;
using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Property;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.Entities.Models;

public class Property:AuditableEntity<Guid>
{
    public PropertyName Name { get; set; }
}