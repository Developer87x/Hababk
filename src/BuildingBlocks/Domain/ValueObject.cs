// ReSharper disable All

using MediatR;

namespace Hababk.BuildingBlocks.Domain;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();


    protected static bool EqualOperator(ValueObject? left, ValueObject? right)
    {
        if(ReferenceEquals(left,null) ^ ReferenceEquals(right,null))return false;
        return ReferenceEquals(left,null) || left.Equals(right);
    }
    protected static bool NotEqualOperator(ValueObject? left, ValueObject? right)
    {
        return !(EqualOperator(left,right));
    }

    public override bool Equals(object? obj)
    {
        if(obj is null || obj.GetType() != GetType())
        {
            return false;
        }
        var valueObject = (ValueObject)obj;
        
        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents().Select(x => x !=null ? x.GetHashCode() : 0).Aggregate((x, y) => x ^ y);  
    }

    public ValueObject? Copy => this.MemberwiseClone() as ValueObject;
}