using System.ComponentModel.DataAnnotations.Schema;
using Shared.Domain;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;
using WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Objects;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

public class StorageLocation : Entity<Guid>
{
    public Guid WarehouseId { get; private set; }
    public Warehouse Warehouse { get; private set; }
    
    public StorageAddress Address { get; private set; }


    private StorageLocation() { }

    private StorageLocation(Guid id, Warehouse warehouse, StorageAddress address) : base(id)
    {
        WarehouseId = warehouse.Id;
        Warehouse = warehouse;
        
        Address = address;
    }
    
    internal static StorageLocation Create(Warehouse warehouse, string zone, string shelf, string bin)
    {
        // استفاده از Pattern Matching برای چک کردن نال نبودن و خالی نبودن Id
        if (warehouse is not { Id: var warehouseId } || warehouseId == Guid.Empty)
        {
            throw new StorageLocationInvalidWarehouseBaseDomainException();
        }

        // ایجاد Value Object (اعتبارسنجی داخلی آدرس)
        var address = new StorageAddress(zone, shelf, bin);

        return new StorageLocation(Guid.NewGuid(), warehouse, address);
    }

    public string GetFullAddress() => Address.ToString();
}