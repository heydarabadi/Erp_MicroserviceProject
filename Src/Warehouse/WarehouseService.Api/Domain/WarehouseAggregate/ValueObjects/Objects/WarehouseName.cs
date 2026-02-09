using Shared.Domain;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;
using WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Objects;


public class WarehouseName : ValueObject
{
    public string Value { get; init; }


    private WarehouseName()
    {
        
    }
    
    private WarehouseName(string value)
    {
        // تمام قوانین اعتبارسنجی نام اینجا متمرکز می‌شود
        if (string.IsNullOrWhiteSpace(value))
            throw new WarehouseBaseNameRequiredDomainException();

        if (value.Length is < 3 or > 100)
            throw new InvalidWarehouseBaseNameLengthException(value.Length);

        Value = value;
    }

    public static WarehouseName Create(string value) => new(value);

    // تبدیل ضمنی (Implicit Conversion) برای راحتی کار با رشته‌ها
    public static implicit operator string(WarehouseName name) => name.Value;
    
    public override string ToString() => Value;

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}