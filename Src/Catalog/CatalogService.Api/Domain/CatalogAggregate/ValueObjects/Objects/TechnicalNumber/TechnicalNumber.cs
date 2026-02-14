using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.TechnicalNumber;

public class TechnicalNumber:ValueObject
{
    public string Value { get; init; }
    
    private TechnicalNumber() { }

    private TechnicalNumber(string inputTechnicalNumber)
    {
        if (string.IsNullOrWhiteSpace(inputTechnicalNumber))
        {
            throw new ArgumentNullException(nameof(inputTechnicalNumber));
        }
        
        this.Value = inputTechnicalNumber;
    }

    public TechnicalNumber Create(string value)
    {
        return new TechnicalNumber(value);
    }
    public override string ToString() => this.Value;
    public static implicit operator string(TechnicalNumber technicalNumber) => technicalNumber.Value;
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}