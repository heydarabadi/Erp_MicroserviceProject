using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.MoneyUnits;

public class Rial:NumericValueObject<Rial>
{
    public decimal Value { get; init; }
    private Rial() { }

    private Rial(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Value cannot be negative", nameof(value));
        }
        Value = value;
    }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    protected override Rial AddCore(Rial other)
    {
        return new Rial(Value + other.Value);
    }

    protected override Rial SubtractCore(Rial other)
    {
        return new Rial(Value - other.Value);
    }

    protected override Rial MultiplyCore(Rial other)
    {
        throw new NotImplementedException();
    }

    protected override Rial DivideCore(Rial other)
    {
        throw new NotImplementedException();
    }
    public static implicit operator decimal(Rial rial) => rial.Value;
}