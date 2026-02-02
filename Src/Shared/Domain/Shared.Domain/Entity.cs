namespace Shared.Domain;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
{
    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
        Id = id;
    }

    // برای استفاده در ORM
    protected Entity() { }



    #region Equality Checks
    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other) return false;
        if (ReferenceEquals(this, other)) return true;
        if (IsTransient() || other.IsTransient()) return false;

        return Id!.Equals(other.Id);
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    // بررسی اینکه آیا موجودیت هنوز ID نگرفته است (ذخیره نشده)
    public bool IsTransient()
    {
        return Id == null || Id.Equals(default(TId));
    }

    public static bool operator ==(Entity<TId>? a, Entity<TId>? b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Entity<TId>? a, Entity<TId>? b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        if (IsTransient()) return base.GetHashCode();
        return HashCode.Combine(GetType(), Id);
    }
    #endregion
    
}

// برای راحتی، نسخه پیش‌فرض با Guid را هم تعریف می‌کنیم
public abstract class Entity : Entity<Guid>
{
    protected Entity(Guid id) : base(id) { }
    protected Entity() : base(Guid.NewGuid()) { }
}