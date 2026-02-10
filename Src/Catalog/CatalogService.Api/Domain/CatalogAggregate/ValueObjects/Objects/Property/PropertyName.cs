using CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Exceptions.Property;
using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Property;

public class PropertyName : ValueObject
{
    public string Value { get; init; }
    private PropertyName()
    {
        
    }
    private PropertyName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new PropertyNameRequiredException();
        }
        if (value.Length < 3 || value.Length > 100)
        {
            throw new PropertyNameLenghtException();
        }
        Value = value;
    }
    public static PropertyName Create(string value)
    {
        PropertyName propertyName = new PropertyName(value);
        return propertyName;
    }
    public override string ToString() => Value;
    public static implicit operator string(PropertyName propertyName) => propertyName.Value;
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}