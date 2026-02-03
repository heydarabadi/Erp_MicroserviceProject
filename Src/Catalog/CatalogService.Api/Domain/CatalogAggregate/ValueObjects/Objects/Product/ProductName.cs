using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Exceptions.Product;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Product;

public class ProductName : ValueObject
{
    public string Value { get; init; }

    private ProductName()
    {
        
    }
    
    private ProductName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ProductNameRequiredException();
        }

        if (value.Length < 3 || value.Length > 100)
        {
            throw new ProductgNameLengthException();
        }
        Value = value;
    }

    public override string ToString() => Value;
    public static explicit operator string(ProductName productName) => productName.ToString();

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}