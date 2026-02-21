using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.SaleSteps;

public class SaleStep:NumericValueObject<SaleStep>
{
    private decimal Value { get; init; }
    private SaleStep() { }
    public static implicit operator decimal(SaleStep saleStep) => saleStep.Value;
    private SaleStep(decimal value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("step cannot be negative or zero", nameof(value));
        }
        Value = value;
    }
    public static SaleStep Create(decimal value)
    {
        return new SaleStep(value);
    }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}