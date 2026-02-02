namespace Shared.Domain;

public abstract class AuditableAggregateRoot<TId> : AggregateRoot<TId>, IAuditable, ISoftDeletable
{
    public DateTime CreatedAtUtc { get; protected set; }
    public DateTime? ModifiedAtUtc { get; protected set; }
    public string? CreatedBy { get; protected set; }

    public bool IsDeleted { get; protected set; }
    public DateTime? DeletedAtUtc { get; protected set; }

    protected AuditableAggregateRoot(TId id) : base(id) => CreatedAtUtc = DateTime.UtcNow;
    protected AuditableAggregateRoot() => CreatedAtUtc = DateTime.UtcNow;

    public void Delete() { IsDeleted = true; DeletedAtUtc = DateTime.UtcNow; }
    public void UndoDelete() { IsDeleted = false; DeletedAtUtc = null; }
    public void SetModified() => ModifiedAtUtc = DateTime.UtcNow;
    
    
    
}