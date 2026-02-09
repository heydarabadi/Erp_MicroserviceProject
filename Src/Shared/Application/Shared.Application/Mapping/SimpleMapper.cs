using System.Reflection;

namespace Shared.Application.Mapping;

public static class SimpleMapper
{
    
    private static readonly Dictionary<Type, PropertyInfo[]> _propertyCache = new();

    private static PropertyInfo[] GetCachedProperties(Type type)
    {
        if (!_propertyCache.TryGetValue(type, out var props))
        {
            props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(p => p.CanRead && p.CanWrite)
                        .ToArray();

            _propertyCache[type] = props;
        }
        return props;
    }


    public static TDestination Map<TSource, TDestination>(TSource? source)
        where TDestination : class, new()
    {
        if (source is null)
            return default!;

        var destination = new TDestination();
        MapInto(source, destination);
        return destination;
    }


    public static void MapInto<TSource, TDestination>(TSource? source, TDestination destination)
        where TDestination : class
    {
        if (source is null || destination is null)
            return;

        var sourceProps = GetCachedProperties(typeof(TSource));
        var destPropsDict = GetCachedProperties(typeof(TDestination))
                                .ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);

        foreach (var srcProp in sourceProps)
        {
            if (!destPropsDict.TryGetValue(srcProp.Name, out var destProp))
                continue;

            object? value;
            try
            {
                value = srcProp.GetValue(source);
            }
            catch
            {
                continue; 
            }

            
            if (value is null && !destProp.PropertyType.IsValueType)
            {
                try { destProp.SetValue(destination, null); }
                catch { }
                continue;
            }

            
            object? finalValue = TryConvert(value, destProp.PropertyType);
            if (finalValue != null || destProp.PropertyType.IsValueType)
            {
                try
                {
                    destProp.SetValue(destination, finalValue);
                }
                catch
                {
                    
                }
            }
        }
    }

    
    
    
    private static object? TryConvert(object? value, Type targetType)
    {
        if (value is null) return null;
        if (targetType.IsAssignableFrom(value.GetType())) return value;

        try
        {
            if (targetType == typeof(string))
                return value.ToString();

            if (value is IConvertible convertible)
                return Convert.ChangeType(value, Nullable.GetUnderlyingType(targetType) ?? targetType);
        }
        catch { }

        return value; 
    }

    
    
    
    public static List<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource>? sources)
        where TDestination : class, new()
    {
        if (sources is null) return new List<TDestination>();

        return sources.Select(Map<TSource, TDestination>).ToList();
    }

    
    
    
    public static void MapListInto<TSource, TDestination>(
        IEnumerable<TSource>? sources,
        IList<TDestination> destinations)
        where TDestination : class
    {
        if (sources is null || destinations is null) return;

        var srcList = sources.ToList();
        int minCount = Math.Min(srcList.Count, destinations.Count);

        for (int i = 0; i < minCount; i++)
        {
            MapInto(srcList[i], destinations[i]);
        }
    }

    public static void ClearCache() => _propertyCache.Clear();
}