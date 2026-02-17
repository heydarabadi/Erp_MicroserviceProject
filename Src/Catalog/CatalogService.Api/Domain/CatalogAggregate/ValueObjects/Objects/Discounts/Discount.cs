using Shared.Domain;

namespace CatalogService.Api.Domain.CatalogAggregate.ValueObjects.Objects.Discounts;

public class Discount:NumericValueObject<Discount>
{
    private decimal Value { get; init; }
    public string Description { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }

    public static implicit operator decimal (Discount discount)
    {
        if (discount.StartDate.HasValue && discount.EndDate.HasValue)
        {
            if (discount.StartDate <= DateTime.UtcNow && discount.EndDate >= DateTime.UtcNow)
            {
                return discount.Value;
            }
            else
            {
                throw new ArgumentException($"Passed periodic start date and end date Date Time Now {DateTime.Now}");
            }
        }
        else
        {
            return discount.Value;
        }
    }
    
    private Discount() { }

    private Discount(decimal value, string description, DateTime? startDate, DateTime? endDate)
    {
        if (value <= 0 || value >= 100)
        {
            throw new ArgumentException($"invalid Discount percentage (discount Percent must be between 0 to 100){value}");
        } 
        if (startDate.HasValue && endDate.HasValue)
        {
            if (startDate >= endDate)
            {
                throw new ArgumentException($"invalid start date and end date Period {startDate}-{endDate}");
            }

            if (startDate > DateTime.UtcNow || endDate < DateTime.UtcNow)
            {
                throw new ArgumentException($"invalid start date and end date range from date time now {DateTime.Now}");
            }
            this.Value = value;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
        else
        {
            this.Value = value;
            this.Description = description;
        }
    }

    public static Discount Create(decimal value, string description, DateTime? startDate = null, DateTime? endDate = null)
    {
        return new Discount(value,description,startDate,endDate);
    }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
    
}