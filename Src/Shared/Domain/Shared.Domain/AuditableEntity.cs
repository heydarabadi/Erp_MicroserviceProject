namespace Shared.Domain;

public abstract class AuditableEntity<TId> : Entity<TId>, IAuditable, ISoftDeletable
{
    // فیلدهای Audit
    public DateTime CreatedAtUtc { get; protected set; }
    public DateTime? ModifiedAtUtc { get; protected set; }
    public string? CreatedBy { get; }

    // فیلدهای Soft Delete
    public bool IsDeleted { get; protected set; }
    public DateTime? DeletedAtUtc { get; protected set; }

    protected AuditableEntity(TId id) : base(id) 
    {
        CreatedAtUtc = DateTime.UtcNow;
    }

    protected AuditableEntity() 
    {
        CreatedAtUtc = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        DeletedAtUtc = DateTime.UtcNow;
    }

    public void UndoDelete()
    {
        IsDeleted = false;
        DeletedAtUtc = null;
    }

    public void SetModified()
    {
        ModifiedAtUtc = DateTime.UtcNow;
    }
}