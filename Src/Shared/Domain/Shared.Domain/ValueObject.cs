namespace Shared.Domain;

public abstract class ValueObject : IEquatable<ValueObject>
{
    // اجباری کردن پیاده‌سازی فیلدها برای مقایسه
    protected abstract IEnumerable<object?> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    // پیاده‌سازی IEquatable برای کارایی بالاتر در مجموعه‌ها
    public bool Equals(ValueObject? other)
    {
        return Equals((object?)other);
    }

    public override int GetHashCode()
    {
        // استفاده از HashCode.Combine برای ترکیب ایمن و بهینه هش‌ها
        return GetEqualityComponents()
            .Aggregate(new HashCode(), (hash, obj) =>
            {
                hash.Add(obj);
                return hash;
            })
            .ToHashCode();
    }

    // Overload کردن اپراتورها برای نوشتن کد تمیزتر در دامنه
    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }

    // متد کمکی برای کپی کردن (بسیار مفید برای رعایت Immutability)
    protected T Copy<T>() where T : ValueObject
    {
        return (T)this.MemberwiseClone();
    }
}