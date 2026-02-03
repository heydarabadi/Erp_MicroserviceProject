using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Category;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.Entities.Models;

public class Category:AuditableEntity<Guid>
{
    public CategoryName Name { get; private set; }
}