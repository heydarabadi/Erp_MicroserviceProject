using System.ComponentModel.DataAnnotations.Schema;
using Shared.Domain;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;

namespace WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Objects;

[ComplexType]                      // Optional but makes intention clear
public class StorageAddress : ValueObject
{
    public string Zone { get; }
    public string Shelf { get; }
    public string Bin { get; }

    public StorageAddress(string zone, string shelf, string bin)
    {
        if (string.IsNullOrWhiteSpace(zone)) throw new StorageLocationInvalidException("Zone cannot be empty.");
        if (string.IsNullOrWhiteSpace(shelf)) throw new StorageLocationInvalidException("Shelf cannot be empty.");
        if (string.IsNullOrWhiteSpace(bin)) throw new StorageLocationInvalidException("Bin cannot be empty.");

        Zone = zone;
        Shelf = shelf;
        Bin = bin;
    }
    
    private StorageAddress(){}

    public override string ToString() => $"{Zone}-{Shelf}-{Bin}";

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Zone;
        yield return Shelf;
        yield return Bin;
    }
}