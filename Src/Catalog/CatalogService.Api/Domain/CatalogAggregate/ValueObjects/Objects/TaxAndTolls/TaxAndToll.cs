using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.TaxAndTolls;

public class TaxAndToll:NumericValueObject<TaxAndToll>
{
    private decimal Value { get; }
    public bool IsActive { get; }
    public static implicit operator decimal (TaxAndToll taxAndToll) => taxAndToll.IsActive ? taxAndToll.Value : 0m;
    private TaxAndToll()
    {
    }
    private TaxAndToll(decimal value, bool isActive)
    {
        if (value < 0 || value > 100)
        {
            throw new ArgumentException("Percentage must be between 0 and 100.", nameof(value));
        }
        Value = value;
        IsActive = isActive;
    }
    public static TaxAndToll Create(decimal percentage, bool isActive)
    {
        return new TaxAndToll(percentage, isActive);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}