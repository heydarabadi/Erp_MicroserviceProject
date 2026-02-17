using Shared.Domain;
using WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Objects;

public class Location : ValueObject
{
    public string Address { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    private Location(){}
    
    private Location(string address, double lat, double lon)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new AddressRequiredException();

        if (lat is < -90 or > 90 || lon is < -180 or > 180)
            throw new InvalidCoordinatesException(lat, lon);

        Address = address;
        Latitude = lat;
        Longitude = lon;
    }

    public static Location Create(string address, double lat, double lon) 
        => new(address, lat, lon);

    public override string ToString() => $"{Address} ({Latitude}, {Longitude})";

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Address.ToLowerInvariant();
        yield return Latitude;
        yield return Longitude;
    }
}