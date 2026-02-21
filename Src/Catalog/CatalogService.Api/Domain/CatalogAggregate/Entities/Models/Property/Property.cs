using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Property;
using MongoDB.Bson;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.Entities.Models.Property;

public class Property:AuditableEntity<ObjectId>
{
    public Guid DomainId { get; private set; }
    public PropertyName Name { get; private set; }
    
}