namespace Shared.Domain;

public abstract class NumericValueObject<TSelf> 
    : IEquatable<TSelf>
    where TSelf : NumericValueObject<TSelf>
{
    protected abstract IEnumerable<object?> GetEqualityComponents();
    protected abstract TSelf AddCore(TSelf other);
    protected abstract TSelf SubtractCore(TSelf other);
    protected abstract TSelf MultiplyCore(TSelf other);
    protected abstract TSelf DivideCore(TSelf other);
    
    public static TSelf operator + (
        NumericValueObject<TSelf> left,
        NumericValueObject<TSelf> right)
    {
        return left.AddCore((TSelf)right);
    }
    
    public static TSelf operator - (       
        NumericValueObject<TSelf> left,
        NumericValueObject<TSelf> right)
    {
        return left.SubtractCore((TSelf)right);
    }
    public static TSelf operator * (       
        NumericValueObject<TSelf> left,
        NumericValueObject<TSelf> right)
    {
        return left.MultiplyCore((TSelf)right);
    }    public static TSelf operator / (       
        NumericValueObject<TSelf> left,
        NumericValueObject<TSelf> right)
    {
        return left.DivideCore((TSelf)right);
    }
    public bool Equals(TSelf? other)
    {
        if (other is null) return false;
        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    public override bool Equals(object? obj)
        => obj is TSelf other && Equals(other);

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(new HashCode(), (hash, obj) =>
            {
                hash.Add(obj);
                return hash;
            })
            .ToHashCode();
    }
}
