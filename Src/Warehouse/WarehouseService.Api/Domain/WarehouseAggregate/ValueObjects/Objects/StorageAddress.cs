using System.ComponentModel.DataAnnotations.Schema;
using Shared.Domain;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Objects;

public class StorageAddress : ValueObject
{
    public string Zone { get; init; }
    public string Shelf { get; init; }
    public string Bin { get; init; }

    private StorageAddress() {}
    
    public StorageAddress(string zone, string shelf, string bin)
    {
        if (string.IsNullOrWhiteSpace(zone)) throw new StorageLocationInvalidBaseDomainException("Zone cannot be empty.");
        if (string.IsNullOrWhiteSpace(shelf)) throw new StorageLocationInvalidBaseDomainException("Shelf cannot be empty.");
        if (string.IsNullOrWhiteSpace(bin)) throw new StorageLocationInvalidBaseDomainException("Bin cannot be empty.");

        Zone = zone;
        Shelf = shelf;
        Bin = bin;
    }
    

    public override string ToString() => $"{Zone}-{Shelf}-{Bin}";

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Zone;
        yield return Shelf;
        yield return Bin;
    }
}