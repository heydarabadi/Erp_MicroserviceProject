using Shared.Domain;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;
using WarehouseService.Api.Domain.WarehouseAggregate.Events;
using WarehouseService.Api.Domain.WarehouseAggregate.ValueObjects.Objects;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

public class Warehouse : AuditableAggregateRoot<Guid>
{
    public WarehouseName Name { get; private set; }
    public Location Location { get; private set; }
    public int Capacity { get; private set; }
    public bool IsActive { get; private set; }

    private readonly List<StorageLocation> _storageLocations = new();
    public IReadOnlyCollection<StorageLocation> StorageLocations => _storageLocations.AsReadOnly();

    // این فیلد اختیاری است؛ اگر بخواهید در لحظه لود شدن انبار، 
    // بدانید چقدر از ظرفیت اشغال شده است (مثلاً از طریق یک فیلد محاسباتی در دیتابیس)
    public int CurrentOccupiedCapacity { get; private set; }
    
    // سازنده برای EF Core
    private Warehouse()
    {
    }

    // سازنده اصلی (جایگزین Factory Method برای رویکرد Exception-Based)
    public Warehouse(Guid id, string name, Location location, int capacity) : base(id)
    {
        ValidateName(name);
        ValidateCapacity(capacity);

        if (location == null)
            throw new WarehouseLocationRequiredDomainException();

        Name = WarehouseName.Create(name);
        Location = location;
        Capacity = capacity;
        IsActive = true;

        AddDomainEvent(new WarehouseCreatedEvent(Id, Name, Capacity));
    }

    // --- متدهای بیزنسی (Behavioral Methods) ---

    public void AddStorageLocation(string zone, string shelf, string bin)
    {
        // استفاده از فکتوری برای ایجاد شیء
        var storageLocation = StorageLocation.Create(this, zone, shelf, bin);

        // بررسی تکراری نبودن در لیست فعلی انبار
        if (_storageLocations.Any(x => x.Address == storageLocation.Address))
            throw new DuplicateStorageLocationDomainException(zone, shelf, bin);

        _storageLocations.Add(storageLocation);

        AddDomainEvent(new StorageLocationDefinedEvent(Id, storageLocation.Id, storageLocation.GetFullAddress()));
    }

    public void UpdateCapacity(int newCapacity)
    {
        ValidateCapacity(newCapacity);

        if (newCapacity < Capacity * 0.5)
            throw new WarehouseCapacityReductionLimitDomainException();

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
            throw new WarehouseAlreadyDeactivatedDomainException();

        IsActive = false;
        SetModified();

        AddDomainEvent(new WarehouseDeactivatedEvent(Id));
    }

    // --- Private Guards (کدهای تکراری اعتبارسنجی) ---

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new WarehouseNameRequiredDomainException();
    }

    private static void ValidateCapacity(int capacity)
    {
        if (capacity <= 0)
            throw new InvalidWarehouseCapacityDomainException();
    }
    
    
    // متدی برای بررسی اینکه آیا انبار فضای خالی برای مقدار مشخصی کالا دارد یا خیر
    public void EnsureHasSpace(int requestedQuantity, int currentTotalStock)
    {
        if (currentTotalStock + requestedQuantity > Capacity)
            throw new WarehouseAtCapacityDomainException();
    }

    // متدی برای ثبت انتساب کالا به انبار (بدون نگه داشتن لیست در حافظه)
    public void RegisterInventoryItem(string sku)
    {
        if (!IsActive)
            throw new WarehouseAlreadyDeactivatedDomainException();

        // در اینجا منطق خاصی اگر برای شروع انتساب نیاز است اضافه می‌شود
        AddDomainEvent(new InventoryAssignedToWarehouseEvent(Id, sku));
    }

    // اصلاح متد تغییر ظرفیت برای جلوگیری از تداخل با موجودی فعلی
    public void UpdateCapacity(int newCapacity, int currentTotalOccupied)
    {
        ValidateCapacity(newCapacity);

        if (newCapacity < currentTotalOccupied)
            throw new WarehouseCapacityInsufficientForLocationsDomainException(); // اکسپشنی که قبلاً ساختیم

        if (newCapacity < Capacity * 0.5)
            throw new WarehouseCapacityReductionLimitDomainException();

        Capacity = newCapacity;
        SetModified();

        AddDomainEvent(new WarehouseCapacityChangedEvent(Id, newCapacity));
    }
    
    
    public void ValidateInventoryAssignment(int quantity)
    {
        if (!IsActive)
            throw new WarehouseNotActiveDomainException();

        if (CurrentOccupiedCapacity + quantity > Capacity)
            throw new WarehouseAtCapacityDomainException();
    }

    // متد برای به‌روزرسانی مقدار اشغال شده (توسط Domain Service یا بعد از دریافت ایونت)
    public void UpdateOccupiedCapacity(int totalItemsCount)
    {
        if (totalItemsCount > Capacity)
            throw new WarehouseAtCapacityDomainException();

        CurrentOccupiedCapacity = totalItemsCount;
        SetModified();
    }

    // ایونت برای اطلاع‌رسانی انتساب کالا
    public void NotifyInventoryAdded(string sku, int quantity)
    {
        ValidateInventoryAssignment(quantity);
        
        // ثبت واقعه برای سیستم‌های خارجی یا StockMovement
        AddDomainEvent(new InventoryAssignedToWarehouseEvent(Id, sku, quantity));
    }
}