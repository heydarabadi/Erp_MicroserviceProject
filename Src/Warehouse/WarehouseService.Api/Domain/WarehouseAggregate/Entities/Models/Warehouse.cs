using Shared.Domain;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;
using WarehouseService.Api.Domain.WarehouseAggregate.Events;
using WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Objects;
using WarehouseService.Api.Shared.Dtos;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

public class Warehouse : AuditableAggregateRoot<Guid>
{
    public WarehouseName Name { get; private set; }
    public Location Location { get; private set; }
    public int Capacity { get; private set; }
    public bool IsActive { get; private set; }

    private readonly List<StorageLocation> _storageLocations = new();
    public IReadOnlyCollection<StorageLocation> StorageLocations => _storageLocations.AsReadOnly();


    public int CurrentOccupiedCapacity { get; private set; }
    
    private Warehouse()
    {
    }

    internal static Warehouse Create(
        string name,
        LocationDto location,
        int capacity,
        Guid? id=null)
    {
        id ??= Guid.NewGuid();
        
        ValidateName(name);
        ValidateCapacity(capacity);

        if (location == null)
            throw new WarehouseBaseLocationRequiredDomainException();

        var warehouse = new Warehouse
        {
            Id        = id.Value,
            Name      = WarehouseName.Create(name),
            Location  = ValueObjects.Objects.Location.Create(location.Address,
                location.Latitude, location.Longtitide),
            Capacity  = capacity,
            IsActive  = true
        };
        
        return warehouse;
    }
    
    private Warehouse(Guid id, string name, Location location, int capacity) : base(id)
    {
        ValidateName(name);
        ValidateCapacity(capacity);

        if (location == null)
            throw new WarehouseBaseLocationRequiredDomainException();

        Name = WarehouseName.Create(name);
        Location = location;
        Capacity = capacity;
        IsActive = true;

        AddDomainEvent(new WarehouseCreatedEvent(Id, Name, Capacity));
    }


    public void AddStorageLocation(string zone, string shelf, string bin)
    {
        // استفاده از فکتوری برای ایجاد شیء
        var storageLocation = StorageLocation.Create(this, zone, shelf, bin);

        // بررسی تکراری نبودن در لیست فعلی انبار
        if (_storageLocations.Any(x => x.Address == storageLocation.Address))
            throw new DuplicateStorageLocationBaseDomainException(zone, shelf, bin);

        _storageLocations.Add(storageLocation);

        AddDomainEvent(new StorageLocationDefinedEvent(Id, storageLocation.Id, storageLocation.GetFullAddress()));
    }

    public void UpdateCapacity(int newCapacity)
    {
        ValidateCapacity(newCapacity);

        if (newCapacity < Capacity * 0.5)
            throw new WarehouseBaseCapacityReductionLimitDomainException();

        Capacity = newCapacity;
        SetModified();

        AddDomainEvent(new WarehouseCapacityChangedEvent(Id, newCapacity));
    }

    public void Rename(string newName)
    {
        Name = WarehouseName.Create(newName);
        SetModified();
        
        // ایونت را با نام جدید ثبت می‌کنیم
        AddDomainEvent(new WarehouseRenamedEvent(Id, Name));
    }

    public void Deactivate()
    {
        if (!IsActive)
            throw new WarehouseBaseAlreadyDeactivatedDomainException();

        IsActive = false;
        SetModified();

        AddDomainEvent(new WarehouseDeactivatedEvent(Id));
    }


    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new WarehouseBaseNameRequiredDomainException();
    }

    private static void ValidateCapacity(int capacity)
    {
        if (capacity <= 0)
            throw new InvalidWarehouseBaseCapacityDomainException();
    }
    
    
    public void EnsureHasSpace(int requestedQuantity, int currentTotalStock)
    {
        if (currentTotalStock + requestedQuantity > Capacity)
            throw new WarehouseBaseAtCapacityDomainException();
    }

    public void RegisterInventoryItem(string sku)
    {
        if (!IsActive)
            throw new WarehouseBaseAlreadyDeactivatedDomainException();

        // در اینجا منطق خاصی اگر برای شروع انتساب نیاز است اضافه می‌شود
        AddDomainEvent(new InventoryAssignedToWarehouseEvent(Id, sku));
    }

    public void UpdateCapacity(int newCapacity, int currentTotalOccupied)
    {
        ValidateCapacity(newCapacity);

        if (newCapacity < currentTotalOccupied)
            throw new WarehouseBaseCapacityInsufficientForLocationsDomainException(); // اکسپشنی که قبلاً ساختیم

        if (newCapacity < Capacity * 0.5)
            throw new WarehouseBaseCapacityReductionLimitDomainException();

        Capacity = newCapacity;
        SetModified();

        AddDomainEvent(new WarehouseCapacityChangedEvent(Id, newCapacity));
    }
    
    
    public void ValidateInventoryAssignment(int quantity)
    {
        if (!IsActive)
            throw new WarehouseBaseNotActiveDomainException();

        if (CurrentOccupiedCapacity + quantity > Capacity)
            throw new WarehouseBaseAtCapacityDomainException();
    }

    public void UpdateOccupiedCapacity(int totalItemsCount)
    {
        if (totalItemsCount > Capacity)
            throw new WarehouseBaseAtCapacityDomainException();

        CurrentOccupiedCapacity = totalItemsCount;
        SetModified();
    }

    public void NotifyInventoryAdded(string sku, int quantity)
    {
        ValidateInventoryAssignment(quantity);
        
        // ثبت واقعه برای سیستم‌های خارجی یا StockMovement
        AddDomainEvent(new InventoryAssignedToWarehouseEvent(Id, sku, quantity));
    }
}