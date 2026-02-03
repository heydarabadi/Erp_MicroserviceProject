using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Exceptions.Category;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Category;

public class CategoryName: ValueObject
{
    public string Value { get;private set; }

    private CategoryName()
    {
        
    }
    private CategoryName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new CategoryNameRequiredException();
        }

        if (value.Length > 100 || value.Length < 3)
        {
            throw new CategoryNameLenghtException();
        }
        Value = value;
    }

    public override string ToString() => Value;
    
    public static implicit operator string(CategoryName categoryName) => categoryName.Value;
    public static CategoryName Create(string value)
    {
        CategoryName categoryName = new CategoryName(value);
        return categoryName;
    }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}