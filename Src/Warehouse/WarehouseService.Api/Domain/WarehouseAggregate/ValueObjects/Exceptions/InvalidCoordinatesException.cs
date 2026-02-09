using WarehouseService.Api.Domain.WarehouseAggregate.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Exceptions;

public class InvalidCoordinatesException : WarehouseBaseDomainException
{
    public InvalidCoordinatesException(double lat, double lon) 
        : base($"مختصات جغرافیایی نامعتبر است. (Lat: {lat}, Lon: {lon})", "Warehouse.InvalidCoordinates") { }
}