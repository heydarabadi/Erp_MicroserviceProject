using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.MoneyUnits;

public class Price :NumericValueObject<Price>
{
    public Rial Value { get; private set; }
    public static Price FromString (string value) => new Price(Rial.FromString(value));
    public static Price FromDecimal (decimal value) => new Price(Rial.FromDecimal(value));
    
    private Price() { }

    private Price(Rial inputRial)
    {
        if (inputRial.Value < 0)
        {
            throw new ArgumentException("Price cannot be negative", nameof(inputRial.Value));
        }
        Value = inputRial;
    }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value.Value;
    }

    protected override Price AddCore(Price other)
    {
        return new Price(Value + other.Value);
    }

    protected override Price SubtractCore(Price other)
    {
        return new Price(Value - other.Value); 
    }

    protected override Price MultiplyCore(Price other)
    {
        throw new NotImplementedException();
    }

    protected override Price DivideCore(Price other)
    {
        throw new NotImplementedException();
    }
    public static implicit operator decimal(Price price) => price.Value.Value;
}