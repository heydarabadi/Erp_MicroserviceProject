using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Property;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.Entities.Models.Property;

public class Property:AuditableEntity<Guid>
{
    public PropertyName Name { get; set; }
}