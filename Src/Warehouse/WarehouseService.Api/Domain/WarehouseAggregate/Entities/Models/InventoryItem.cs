using Shared.Domain;
using WarehouseService.Api.Domain.WarehouseAggregate.Entities.Exceptions;
using WarehouseService.Api.Domain.WarehouseAggregate.Events;

namespace WarehouseService.Api.Domain.WarehouseAggregate.Entities.Models;

public class InventoryItem : AuditableAggregateRoot<Guid>
{
    public string SKU { get; private set; }
    public Guid WarehouseId { get; private set; }
    public Guid? StorageLocationId { get; private set; }
    public int OnHandQuantity { get; private set; }
    public int ReservedQuantity { get; private set; }
    public DateTime? LastMovementDate { get; private set; }
    public byte[] RowVersion { get; private set; }

    public int AvailableQuantity => OnHandQuantity - ReservedQuantity;

    private InventoryItem() { }

    private InventoryItem(Guid id, string sku, Guid warehouseId, Guid? storageLocationId) : base(id)
    {
        SKU = sku;
        WarehouseId = warehouseId;
        StorageLocationId = storageLocationId;
        LastMovementDate = DateTime.UtcNow;
    }

    public static InventoryItem Create(string sku, Guid warehouseId, Guid? storageLocationId = null)
    {
        if (string.IsNullOrWhiteSpace(sku)) throw new SkuRequiredBaseDomainException();
        if (warehouseId == Guid.Empty) throw new InvalidWarehouseBaseIdDomainException();

        return new InventoryItem(Guid.NewGuid(), sku, warehouseId, storageLocationId);
    }

    public void Receive(int quantity)
    {
        if (quantity <= 0) throw new NegativeQuantityBaseDomainException();

        OnHandQuantity += quantity;
        UpdateMovement();
        
        AddDomainEvent(new StockReceivedEvent(SKU, WarehouseId, quantity));
    }

    public void Reserve(int quantity)
    {
        if (quantity <= 0) throw new NegativeQuantityBaseDomainException();
        if (quantity > AvailableQuantity) throw new InsufficientAvailableStockBaseDomainException(SKU, quantity, AvailableQuantity);

        ReservedQuantity += quantity;
        UpdateMovement();
        
        AddDomainEvent(new StockReservedEvent(SKU, WarehouseId, quantity, string.Empty));
    }

    public void Ship(int quantity, string orderId)
    {
        if (quantity <= 0) throw new NegativeQuantityBaseDomainException();
        if (quantity > ReservedQuantity) throw new ShippingExceedsReservedQuantityBaseDomainException(quantity, ReservedQuantity);

        ReservedQuantity -= quantity;
        OnHandQuantity -= quantity;
        UpdateMovement();
        
        AddDomainEvent(new StockShippedEvent(SKU, WarehouseId, quantity, orderId));
    }

    public void Relocate(Guid newStorageLocationId)
    {
        if (newStorageLocationId == Guid.Empty) throw new InvalidStorageLocationIdBaseDomainException();
        
        var oldLocation = StorageLocationId;
        StorageLocationId = newStorageLocationId;
        SetModified();

        AddDomainEvent(new InventoryLocationChangedEvent(Id, SKU, oldLocation, newStorageLocationId));
    }

    public void AdjustStock(int newQuantity, string reason)
    {
        if (newQuantity < 0) throw new NegativeTotalStockBaseDomainException();
        
        OnHandQuantity = newQuantity;
        UpdateMovement();

        AddDomainEvent(new StockAdjustedEvent(SKU, newQuantity, reason));
    }

    public void ReleaseReservation(int quantity)
    {
        if (quantity <= 0) throw new NegativeQuantityBaseDomainException();
        if (quantity > ReservedQuantity) throw new InvalidReservationReleaseBaseDomainException();

        ReservedQuantity -= quantity;
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        LastMovementDate = DateTime.UtcNow;
        SetModified();
    }
}