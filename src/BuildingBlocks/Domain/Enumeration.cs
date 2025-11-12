using System.Reflection;

namespace Hababk.BuildingBlocks.Domain;

public abstract class Enumeration(Guid id, string value) : IComparable
{
    private Guid Id { get; } = id;
    private string Value { get; } = value;

    public int CompareTo(object? obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        return obj is not Enumeration otherEnum ? throw new ArgumentException($"Object must be of type {nameof(Enumeration)}", nameof(obj)) : Id.CompareTo(otherEnum.Id);
    }
    public override string ToString() => Value;

    private static IEnumerable<T> GetAll<T>() where T : Enumeration
    {
        var getFelids = typeof(T).GetFields(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Static);
        return getFelids.Select(x => x.GetValue(null)).Cast<T>();
    }

    private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
    {
        var matchedEnumeration = GetAll<T>().FirstOrDefault(predicate);
        return matchedEnumeration ?? throw new ArgumentException($"Could not find {description} with value: {value}");
    }
    protected static T FromValue<T>(string value) where T : Enumeration => Parse<T, string>(value, nameof(value), x => x.Value == value);
    protected static T FromId<T>(Guid id) where T : Enumeration => Parse<T, Guid>(id, nameof(id), x => x.Id == id);
    
}