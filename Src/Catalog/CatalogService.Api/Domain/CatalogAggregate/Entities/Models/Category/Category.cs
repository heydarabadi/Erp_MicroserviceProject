using System.Text.Json.Serialization;
using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Category;
using MongoDB.Bson;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.Entities.Models.Category;

public class Category:AuditableEntity<ObjectId>
{
    public Guid DomainId { get; private set; }
    public CategoryName Name { get; private set; }
    public Category? Parent { get; private set; }
    public List<Category>? Children { get; private set; }
    [JsonIgnore] public List<ObjectId> ProductsIds { get; private set; } = new List<ObjectId>();


}