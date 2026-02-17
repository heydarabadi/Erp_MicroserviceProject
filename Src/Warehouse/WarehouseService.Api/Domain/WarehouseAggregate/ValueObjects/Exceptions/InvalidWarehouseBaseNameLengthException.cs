using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Exceptions;

public class InvalidWarehouseBaseNameLengthException : WarehouseBaseBaseException
{
    public InvalidWarehouseBaseNameLengthException(int length) 
        : base($"طول نام انبار ({length}) نامعتبر است. باید بین ۳ تا ۱۰۰ کاراکتر باشد.", "Warehouse.InvalidNameLength") { }
}